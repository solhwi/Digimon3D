#!/bin/bash

echo "[postbuild] Copy build outputs from temp dir to Builds dir" 

# Used for local test
#cd /Users/bakseongjin/wkspaces/ProjectSD_Master/builds
# Used for jenkins
cd /Users/bakseongjin/.jenkins/workspace/BuildUnityProject/builds

cd temp

# current build output 
dirs=(*)
echo "[postbuild] Current build output dir name: ${dirs[0]}"

echo "[postbuild] Copying build output to builds dir..."
cp -r ${dirs[0]} ../
cd ..

echo "[postbuild] Start checkin build output process to main branch"
echo "[postbuild] Add local build dir under the source control..."
echo ${dirs[0]}
find -L ${dirs[0]} -name "*" | /usr/local/bin/cm partial add -
echo "[postbuild] checkin build dir..."
/usr/local/bin/cm ci ${dirs[0]}/* -c "[JENKINS] Build output submit, ${dirs[0]}"
echo "[postbuild] Finished checkin"

echo "[postbuild] remove temp dir"
rm -r temp

echo "[postbuild] Everything is ok..."
