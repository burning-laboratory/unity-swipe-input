class Markers{
    static UnityVersionMarker = '{unity_version}';
    static PackageVersionMarker = '{package_version}';
}

class BuildSettings{
    static ManifestPath = './package.json';
    static ReadmeDistPath = './readme-dist.md';
    static ReadmeOutPaths = [
        './README.md',
        './../../../README.md'
    ];
}

const fs = require('fs')

function getUnityVersion(){
    const versionMarker = process.argv.find(u => u == '-unity');
    const unityVersionIndex = process.argv.indexOf(versionMarker) + 1;
    return process.argv[unityVersionIndex]
}

function getPackageVersion(){
    const rawManifest = fs.readFileSync(BuildSettings.ManifestPath);
    const manigest = JSON.parse(rawManifest);
    return manigest.version;
}

function buildReadme(){
       const readmeDist = fs.readFileSync(BuildSettings.ReadmeDistPath);
       const unityVersion = getUnityVersion();
       const packageVersion = getPackageVersion();
       
       const proceedReadme = readmeDist.toString()
           .replace(Markers.UnityVersionMarker, unityVersion)
           .replace(Markers.PackageVersionMarker, packageVersion);
    
       BuildSettings.ReadmeOutPaths.forEach(str => {
          fs.writeFileSync(str, proceedReadme);
       });
}

buildReadme();