# Dependencies Exchange

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](./LICENSE)
[![Build][github-actions-badge]][github-actions]

Tis project contains libraries to exchange assemblies dependencies (import/export)

These libraries are used in *[Dependecy Viewer][dependencies-viewer-url]*.

## Base Features
- Import Assemblies service (with user interface)
- Export Assembles service (with user interface)
- User interface to edit settings

##  Exchange Types

### File

This import/export mechanism saves one assembly and own dependencies in a JSON file. File selection (for import/export) uses windows dialog (platform dependent).

### Graph

This import/export call *[Dependeces Graph Services][dependencies-graph-services-url]* to store assembly and own dependencies in a database.

[dependencies-viewer-url]:              https://github.com/xclemence/Dependencies.Viewer
[dependencies-graph-services-url]:      https://github.com/xclemence/dependencies-graph-services

[github-actions]:                  https://github.com/xclemence/Dependencies.Exchange/actions
[github-actions-badge]:            https://github.com/xclemence/Dependencies.Exchange/workflows/WPF%20.NET%20Core/badge.svg?branch=master
