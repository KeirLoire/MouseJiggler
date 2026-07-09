<div align="center">
    <img src="https://github.com/KeirLoire/MouseJiggler/blob/master/.github/sample.png?raw=true" width="300" alt="MouseJiggler"/>
    <br>
    <b style="font-size:25px">
        MouseJiggler
    </b>
    <br>
    <a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0">
        <img src="https://img.shields.io/badge/8-v8a0dc?label=.NET&style=flat&logo=dotnet" alt=".NET Logo"/>
    </a>
    <a href="https://github.com/KeirLoire/MouseJiggler/commits/main">
        <img src="https://github.com/keirLoire/MouseJiggler/actions/workflows/ci.yml/badge.svg" alt="GitHub CI/CD"/>
    </a>
</div>

## About

Moves the mouse cursor by a small 1-pixel offset to keep the system active. When the jiggler is started, it automatically pauses whenever you move the mouse or press a key, and it resumes once you become idle for 5 seconds or depending on the idle timeout value you used.

## Prerequisites
This binary requires prerequisites in order to run.

- None, all dependencies are embedded in the binary.

## Usage

- Run the binary

```powershell
.\MouseJiggler.exe
```