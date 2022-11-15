# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0-preview.3](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0-preview.3) - 2022-11-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/5?closed=1)  
    

### Fixed

- Fix pool scene creation ([#9](https://github.com/unity-game-framework/ugf-module-pool/issues/9))  
    - Fix `PoolComponentDynamicLoader` class scene access.

## [2.0.0-preview.2](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0-preview.2) - 2022-11-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/4?closed=1)  
    

### Added

- Add component scene reset ([#7](https://github.com/unity-game-framework/ugf-module-pool/issues/7))  
    - Add `PoolComponentDynamicCollection` class support for scene reset on disable.

## [2.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0-preview.1) - 2022-11-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/3?closed=1)  
    

### Fixed

- Fix pool component loading ([#5](https://github.com/unity-game-framework/ugf-module-pool/issues/5))  
    - Update dependencies: `com.ugf.module.assets` to `5.0.0-preview.2` version.
    - Add `PoolModuleAsset` collections replacement support.
    - Add `PoolComponentDynamicCollection` class as implementation of dynamic pool collection for component assets.
    - Fix `PoolComponentDynamicLoader` class to create proper pool collection to work with components.
    - Fix `PoolComponentLoader` class to properly load component from the gameobjects used for the pool collections.
    - Fix `PoolModuleDescription.UnloadOnUninitialize` property usage.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0-preview) - 2022-07-14  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/2?closed=1)  
    

### Changed

- Change string ids to global id data ([#3](https://github.com/unity-game-framework/ugf-module-pool/issues/3))  
    - Update dependencies: `com.ugf.module.assets` to `5.0.0-preview` version.
    - Update package _Unity_ version to `2022.1`.
    - Change usage of ids as `GlobalId` structure instead of `string`.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/1.0.0-preview) - 2022-05-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/1?closed=1)  
    

### Added

- Add implementation ([#1](https://github.com/unity-game-framework/ugf-module-pool/issues/1))  
    - Add `PoolModule` class and _Pool_ collection loaders.


