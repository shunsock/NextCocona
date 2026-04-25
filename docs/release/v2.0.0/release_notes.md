# NextCocona v2.0.0 Release Notes

## Highlights

NextCocona v2.0.0 はターゲットフレームワークの世代交代を行うメジャーリリースです。
.NET 6.0 サポートを廃止し、.NET 10 (LTS) を新たなターゲットに追加しました。

## Breaking Changes

- **.NET 6.0 サポートの廃止**: `net6.0` ターゲットを削除しました。.NET 6.0 環境で使用する場合は v1.x を継続してください。

## What's New

### .NET 10 (LTS) サポート

- `TargetFrameworks` に `net10.0` を追加 (#14)
- SDK を `10.0.100` に更新
- .NET 6.0 向けの条件付きコンパイル (`NullableAttributes.cs` 等) を削除し、コードベースを簡素化 (#13)

### CI/CD の刷新

- Azure Pipelines から GitHub Actions CI に移行
- `v*` タグトリガーによる NuGet publish ワークフローを追加

### Dependabot の導入

- NuGet パッケージと GitHub Actions のバージョン更新を自動化 (#23)
- monthly スケジュール、major バージョンのみ追跡

## Target Frameworks

| Framework | v1.x | v2.0.0 |
|-----------|------|--------|
| net6.0    | o    | -      |
| net8.0    | o    | o      |
| net10.0   | -    | o      |

## Links

- [NuGet: NextCocona](https://www.nuget.org/packages/NextCocona)
- [NuGet: NextCocona.Core](https://www.nuget.org/packages/NextCocona.Core)
- [NuGet: NextCocona.Lite](https://www.nuget.org/packages/NextCocona.Lite)
