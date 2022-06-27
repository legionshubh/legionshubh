#load "operation.cake"
#tool "nuget:?package=GitVersion.CommandLine&version=5.0.0"

// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

// VARIABLES
///////////////////////////////////////////////////////////////////////////////

var packageVersion="";
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Default")
.Does(() => {
	Information("Hello Cake!");
});
Task("version")
.Does(()=> {

	var version= GetSourceVersion();
	GitVersion(new GitVersionSettings{
		UpdateAssemblyInfo=true
		});
	packageVersion=version.FullSemVer;
	Information("version: "+packageVersion);
	Information("version major: "+$"{version.Major}");
	Information("version minor: "+$"{version.Minor}");
	Information("version patch: "+$"{version.Patch}");
	Information("version label: "+$"{version.PreReleaseLabel}");
	Information("version no of commit: "+$"{version.CommitsSinceVersionSource}");
	
	});

RunTarget(target);