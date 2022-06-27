GitVersion GetSourceVersion()
{
    try
    {
        return GitVersion();
    }
    catch(Exception e)
    {
        Information("code executed");
        Information(e.ToString);
        return GetDummyVersion();
    }
}
GitVersion GetDummyVersion()
{
    return new GitVersion{
        BranchName="Unknown",
        Sha = System.Guid.NewGuid().ToString(),
        NuGetVersionV2="0.0.4-unknown"
    };
}