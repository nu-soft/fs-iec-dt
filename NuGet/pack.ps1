$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\build\NuSoft.FSharp.IEC.DataTypes.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\NuGet\NuSoft.FSharp.IEC.DataTypes.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\NuSoft.FSharp.IEC.DataTypes.compiled.nuspec

& $root\NuGet\NuGet.exe pack $root\nuget\NuSoft.FSharp.IEC.DataTypes.compiled.nuspec