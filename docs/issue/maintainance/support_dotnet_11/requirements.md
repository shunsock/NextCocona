# Support .NET 11 and Implement Performance Enhancements

Issue: #15

## 概要

.NET 11 をターゲットフレームワークに追加し、v2.0 の leading edge ターゲットとして位置づける。.NET 11 固有のパフォーマンス機能（Runtime-native Async 等）の活用は、GA リリース後に別途検討する。

## 背景

- .NET 11 は 2026-11 にリリース予定の STS (Standard Term Support) バージョンである
- Issue では Runtime-native Async によるパフォーマンス改善が言及されている
- .NET 11 はまだプレビュー段階であり、Runtime-native Async の API は確定していない
- v2.0 マイルストーンとして、まずターゲットフレームワークの追加を行い、パフォーマンス最適化は GA 後に対応する

## 目的

- .NET 11 ユーザーがネイティブターゲットでライブラリを利用できるようにする
- SDK と CI パイプラインを .NET 11 対応に更新する
- .NET 11 の JIT 改善によるパフォーマンス向上を自動的に享受できる状態にする

## 範囲

### 変更対象

| カテゴリ | ファイル | 対応内容 |
|---------|---------|---------|
| global.json | `global.json` | SDK バージョンを `11.0.100` に更新 |
| csproj | `src/Cocona/Cocona.csproj` | TargetFrameworks に `net11.0` を追加 |
| csproj | `src/Cocona.Core/Cocona.Core.csproj` | 同上 |
| csproj | `src/Cocona.Lite/Cocona.Lite.csproj` | 同上 |
| csproj | `test/Cocona.Test/Cocona.Test.csproj` | TargetFrameworks に `net11.0` を追加 |
| csproj | `test/Cocona.Lite.Test/Cocona.Lite.Test.csproj` | TargetFrameworks に `net11.0` を追加 |
| CI | `.github/workflows/ci.yml` | `dotnet-version` に `11.0.x` を追加 |
| CI | `.github/workflows/publish.yml` | `dotnet-version` に `11.0.x` を追加 |
| ドキュメント | `README.md` | Requirements に `.NET 11` を追加 |

### 対象外

- Runtime-native Async の活用 — API が確定していないため GA 後に別 Issue で対応
- 条件付きコンパイル — `NET8_0_OR_GREATER` ガードは net11.0 でも自動的に有効になるため変更不要
- `NET5_0_OR_GREATER || NETSTANDARD2_1` の条件分岐 — netstandard2.1 との互換に必要なため維持
- サンプルプロジェクト — net8.0 のまま維持
- NuGet パッケージバージョンの更新 — 現行バージョンは net11.0 でも互換性がある
- net8.0 / net10.0 の削除 — サポート期間中のため維持

## 完了条件

- [ ] net11.0 が TargetFrameworks に追加されていること
- [ ] `global.json` が .NET 11 SDK を指定していること
- [ ] CI が net8.0, net10.0, net11.0 でビルド・テストを実行すること
- [ ] `dotnet format` がエラーなく通ること
- [ ] `dotnet build` が全ターゲットで成功すること
- [ ] `dotnet test` が全ターゲットで成功すること
- [ ] CI が green であること
