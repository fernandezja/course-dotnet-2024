[CmdletBinding()]
Param (
    [string]$SolutionDir = "$BuildRoot\src",
    [string]$ProjectName = "Esculturas.DB",
    [string]$BuildDir = "$BuildRoot\Output",
    [string]$Configuration = "Release",
    [string]$ToolsPath = "$BuildRoot\Tools",
    [string]$SqlPackageToolsPath = ""
)

task Clean { 
    Remove-Item "$SolutionDir\$ProjectName\bin" -ErrorAction SilentlyContinue -Force -Recurse
    Remove-Item "$SolutionDir\$ProjectName\obj" -ErrorAction SilentlyContinue -Force -Recurse
    Remove-Item $BuildDir -ErrorAction SilentlyContinue -Force -Recurse

}

task Init {
    
   
}

task Deploy {
    Set-Alias SqlPackage (Resolve-Path "$ToolsPath\SqlPackage\sqlpackage.exe").Path
    $LocalPublishProfile = (Get-ChildItem "$BuildRoot\src\$ProjectName\publish\Local.publish.xml").FullName
    Write-Build Yellow "Deploying database with profile: $LocalPublishProfile"

    #https://learn.microsoft.com/en-us/sql/tools/sql-database-projects/tutorials/create-deploy-sql-project
    exec {
        sqlpackage /Action:Publish /Profile:$LocalPublishProfile /SourceFile:$DacPacFile

    }
}


task Build {
    $Projects = @()
    $Projects += "$SolutionDir\$ProjectName\$ProjectName.sqlproj"
    $Projects | Foreach-Object {
        Write-Build Yellow "Project build: $_"
        exec {
            dotnet build $_ -c $Configuration /p:NetCoreBuild=True -o $BuildDir
        }
    }

    $Script:DacPacFile = (Resolve-Path "$BuildDir\$ProjectName.dacpac").Path
    Write-Build Yellow "DacPac path: $DacPacFile"
}

task . Clean, Build, Init, Deploy