# Changelog

## [v4.0.3] - 2024-03-05

### Updated
- Removed Provider Type Entirely
- Rewrote the factory to respect Provider type removal



## [v4.0.2] - 2023-1-31

### Updated
- Improved Editor Tools
- New Sample Scene
- Code Refactored

## [v4.0.0] - 2023-1-12

### Breaking Changes Introduced

### Added
- AuthSystemInstaller.cs: New installer for the authentication system.
- DefaultProvider.cs: Implementation of a default authentication provider.
- ProviderFactory.cs: Factory class for creating authentication providers.
- ProviderTypes.cs: Enumeration of provider types.
- DontDestroyUtility.cs: Utility to prevent objects from being destroyed on load.
- New samples

### Updated
- AuthenticationManager.cs: Changes to the core authentication management logic.
- ProviderBase.cs: Modifications to the base class for authentication providers.
- UserData.cs: Updates to the user data structure.

## [v3.0.0] - 2023-1-9

- Authentication is now based on Async calls
- Code Cleanup

## [v2.0.6] - 2023-12-19

- Now initialization event is based on unity event for better editor access

## [v2.0.0] - 2023-11-28

- Updated with Steam authentication extension details, installation instructions, and usage guidelines.
- Added AuthenticationManager class with a method to authenticate via a provider

## [v0.1.0] - 2023-11-24

- Added Base Package for the System