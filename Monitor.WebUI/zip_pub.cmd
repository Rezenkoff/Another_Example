del publish-monitor.zip

cd bin\release\netcoreapp2.2\ubuntu.16.04-x64

del publish-monitor.zip

c:\!Deploy\bin\zip.exe  publish-monitor.zip publish\*.* -r

cd ..\..\..\..\

move bin\release\netcoreapp2.2\ubuntu.16.04-x64\publish-monitor.zip %bamboo_build_working_directory%\publish-monitor.zip


