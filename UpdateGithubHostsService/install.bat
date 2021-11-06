%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe UpdateGithubHostsService.exe
Net Start UpdateGithubHostsService
sc config UpdateGithubHostsService start= auto
