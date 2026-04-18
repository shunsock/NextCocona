# Remove EOL TargetFrameworks (net6.0)

Issue: #13

## 概要

TargetFrameworks から EOL を迎えた net6.0 を削除し、関連する条件付きコンパイル・CI 設定・ドキュメントを整理する。

## 背景

- .NET 6.0 は 2024-11-12 にサポート終了 (End of Life) を迎えた
- EOL フレームワークを維持し続けることで、CI の実行時間増加・条件分岐による複雑度上昇・セキュリティリスクが発生する
- v2.0 マイルストーンにおいて、サポート対象フレームワークの整理が求められている

## 目的

- EOL フレームワーク (net6.0) をコードベースから除去し、保守負荷を軽減する
- 条件付きコンパイルの分岐を減らし、コードの認知的複雑度を下げる
- CI パイプラインから不要な SDK インストール・テスト実行を除去する

## 範囲

### 変更対象

| カテゴリ | ファイル | 対応内容 |
|---------|---------|---------|
| csproj | `src/Cocona/Cocona.csproj` | TargetFrameworks から `net6.0` を削除 |
| csproj | `src/Cocona.Core/Cocona.Core.csproj` | 同上 |
| csproj | `src/Cocona.Lite/Cocona.Lite.csproj` | 同上 |
| csproj | `test/Cocona.Test/Cocona.Test.csproj` | TargetFrameworks から `net6.0` を削除 |
| 条件付きコンパイル | `src/Cocona.Core/Internal/ThrowHelper.cs` | `#if NET6_0_OR_GREATER` ガードを除去し、net8.0 向けコードを直接使用。netstandard 向け `#else` ブランチは維持 |
| 条件付きコンパイル | `src/Cocona.Core/Internal/NullabilityInfoContextHelper.cs` | 同上 |
| CI | `.github/workflows/build.yaml` | `dotnet-version` から `6.0.x` を削除 |
| CI | `.azure-pipelines/build.yml` | `UseDotNet@2` の `6.0.x` ステップを削除 |
| ドキュメント | `README.md` | `.NET 6` の記述を削除または更新 |

### 対象外

- `global.json` — SDK バージョンは #14 で対応する
- `netstandard2.0` / `netstandard2.1` — EOL ではなく、下位互換のため維持
- `NET5_0_OR_GREATER || NETSTANDARD2_1` の条件分岐 — netstandard2.1 との互換に必要なため維持
- サンプルプロジェクト — 既に net8.0 のみ対象

## 完了条件

- [ ] net6.0 への参照がコードベースから除去されていること
- [ ] `dotnet format` がエラーなく通ること
- [ ] `dotnet build` が全ターゲットで成功すること
- [ ] `dotnet test` が全ターゲットで成功すること
- [ ] CI が green であること
