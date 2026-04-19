# Target .NET 10 (LTS) and Update SDK

Issue: #14

## 概要

.NET 10 (LTS) をターゲットフレームワークに追加し、SDK バージョンと CI 設定を更新する。既存の net8.0 および netstandard ターゲットは維持する。

## 背景

- .NET 10 は 2025-11 にリリース予定の次期 LTS バージョンである
- Issue に記載の期限は 2026-11-10 であり、v2.0 マイルストーンとして対応が求められている
- net8.0 も LTS（サポート終了 2026-11-10）であるため、現時点では両方をサポートする
- `publish.yml` に #13 で対応漏れとなった `6.0.x` SDK 参照が残存しており、併せて修正する

## 目的

- .NET 10 (LTS) ユーザーがネイティブターゲットでライブラリを利用できるようにする
- SDK と CI パイプラインを .NET 10 対応に更新する
- publish.yml の net6.0 残存参照を修正する

## 範囲

### 変更対象

| カテゴリ | ファイル | 対応内容 |
|---------|---------|---------|
| global.json | `global.json` | SDK バージョンを `10.0.100` に更新し、`rollForward` を `latestFeature` に設定 |
| csproj | `src/Cocona/Cocona.csproj` | TargetFrameworks に `net10.0` を追加 |
| csproj | `src/Cocona.Core/Cocona.Core.csproj` | 同上 |
| csproj | `src/Cocona.Lite/Cocona.Lite.csproj` | 同上 |
| csproj | `test/Cocona.Test/Cocona.Test.csproj` | TargetFrameworks に `net10.0` を追加 |
| csproj | `test/Cocona.Lite.Test/Cocona.Lite.Test.csproj` | TargetFrameworks に `net10.0` を追加 |
| CI | `.github/workflows/ci.yml` | `dotnet-version` に `10.0.x` を追加 |
| CI | `.github/workflows/publish.yml` | `dotnet-version` を `8.0.x` と `10.0.x` に更新（`6.0.x` を削除） |
| ドキュメント | `README.md` | Requirements に `.NET 10` を追加 |

### 対象外

- `netstandard2.0` / `netstandard2.1` — 下位互換のため維持。削除は別 Issue で検討
- net8.0 の削除 — LTS サポート期間中のため維持
- 条件付きコンパイル — `NET8_0_OR_GREATER` ガードは net10.0 でも自動的に有効になるため変更不要
- `NET5_0_OR_GREATER || NETSTANDARD2_1` の条件分岐 — netstandard2.1 との互換に必要なため維持
- サンプルプロジェクト — net8.0 のまま維持（#15 等で検討）
- NuGet パッケージバージョンの更新 — Microsoft.Extensions.* 8.0.0 は net10.0 でも互換性がある
- `test/Cocona.Test/Cocona.Test.csproj` の `LangVersion: 10` — テストの互換性維持のため変更しない

## 完了条件

- [ ] net10.0 が TargetFrameworks に追加されていること
- [ ] `global.json` が .NET 10 SDK を指定していること
- [ ] CI が net8.0 と net10.0 の両方でビルド・テストを実行すること
- [ ] `publish.yml` から `6.0.x` が除去されていること
- [ ] `dotnet format` がエラーなく通ること
- [ ] `dotnet build` が全ターゲットで成功すること
- [ ] `dotnet test` が全ターゲットで成功すること
- [ ] CI が green であること
