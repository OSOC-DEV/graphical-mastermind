/**
* JetBrains Space Automation
* This Kotlin-script file lets you automate build activities
* For more info, see https://www.jetbrains.com/help/space/automation.html
*/

job("build") {
    container("mcr.microsoft.com/dotnet/sdk:5.0")
            shellScript {
            content = """
				dotnet restore
                dotnet build
            """
        }
}
