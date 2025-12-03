<div align="center">
    <img src="https://github.com/KeirLoire/mouse-jiggler/blob/master/.github/sample.png?raw=true" width="300" alt="MouseJiggler"/>
    <br>
    <b style="font-size:25px">
        mouse-jiggler
    </b>
    <br>
    <a href="https://dotnet.microsoft.com/en-us/download/dotnet/9.0">
        <img src="https://img.shields.io/badge/9-v8a0dc?label=.NET&style=flat&logo=dotnet" alt=".NET Logo"/>
    </a>
    <a href="https://github.com/KeirLoire/mouse-jiggler/commits/main">
        <img src="https://github.com/keirLoire/mouse-jiggler/actions/workflows/ci.yml/badge.svg" alt="GitHub CI/CD"/>
    </a>
</div>

## About

Moves the mouse cursor by a small 1-pixel offset to keep the system active. When the jiggler is running, it automatically pauses whenever mouse or keyboard activity is detected, and resumes once the user becomes idle.

## Prerequisites
This binary requires prerequisites in order to run.

- None, all dependencies are embedded in the binary.

## Usage

- Run the binary

```powershell
.\MouseJiggler.exe
```