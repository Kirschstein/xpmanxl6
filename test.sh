nunit3-console C/src/xpmanxl6/Tests/bin/Debug/netcoreapp2.1/Tests.dll
if [ $? -eq 0 ]
then
    git add .
    git commit -am "automatically commit passing test"
else
    git reset --hard
    git clean -fd
fi