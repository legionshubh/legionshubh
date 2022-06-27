﻿#load "operation.cake"
#tool "nuget:?package=GitVersion.CommandLine&version=3.6.5"

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
	packageVersion=version.NuGetVersion;
	Information("version: "+packageVersion);
	Information("version major: "+$"{version.Major}");
	
	});

RunTarget(target);