# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/3.0.0-preview.1) - 2024-08-17  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/11?closed=1)  
    

### Changed

- Update package ([#28](https://github.com/unity-game-framework/ugf-module-pool/issues/28))  
    - Update dependencies: `com.ugf.module.assets` to `6.0.0-preview.2`, add `com.ugf.tables` of `1.0.0-preview.1` version.
    - Change `PoolModule` and related classes to support updated _Application_ package.
    - Add `PoolDescriptionTableAsset` and related classes to define `IPoolDescription` inside tables.

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/3.0.0-preview) - 2023-11-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/10?closed=1)  
    

### Added

- Add pool collection folder ([#22](https://github.com/unity-game-framework/ugf-module-pool/issues/22))  
    - Update dependencies: `com.ugf.module.assets` to `6.0.0-preview.1` version.
    - Update package _Unity_ version to `2023.2`.
    - Update package registry to _UPM Hub_.
    - Add `PoolDescriptionCollectionListFolderAsset` class as implementation of asset folder for `PoolDescriptionCollectionListAsset` collection.

## [2.1.0](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.1.0) - 2023-04-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/9?closed=1)  
    

### Added

- Add pool collection asset ([#20](https://github.com/unity-game-framework/ugf-module-pool/issues/20))  
    - Add `PoolDescriptionCollectionAsset` class as abstract collection of the `IPoolDescription` descriptions.
    - Add `PoolDescriptionCollectionListAsset` class as default implementation of `PoolDescriptionCollectionAsset` class which stores pool descriptions as list of the assets.
    - Add `PoolModuleAsset.Collections` property as collections of the `PoolDescriptionCollectionAsset` classes used to setup pools from collections.

## [2.0.0](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0) - 2023-01-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/8?closed=1)  
    

### Changed

- Update project ([#18](https://github.com/unity-game-framework/ugf-module-pool/issues/18))  
    - Update dependencies: `com.ugf.module.assets` to `5.0.0` and `com.ugf.pool` to `2.0.0` versions.
    - Update package _Unity_ version to `2022.2`.

## [2.0.0-preview.5](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0-preview.5) - 2022-11-19  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/7?closed=1)  
    

### Fixed

- Fix PoolComponentDynamicCollection build on specified scene ([#13](https://github.com/unity-game-framework/ugf-module-pool/issues/13))  
    - Fix `PoolComponentDynamicCollection` class to set scene when new item added to the collection.

## [2.0.0-preview.4](https://github.com/unity-game-framework/ugf-module-pool/releases/tag/2.0.0-preview.4) - 2022-11-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-pool/milestone/6?closed=1)  
    

### Fixed

- Fix pool component disable parent reset ([#11](https://github.com/unity-game-framework/ugf-module-pool/issues/11))  
    - Fix `PoolComponentDynamicCollection` class parent reset.

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


