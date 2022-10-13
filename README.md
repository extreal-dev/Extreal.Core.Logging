# Extreal.Core

このライブラリは Unity 上での動作を想定しています。
また静的解析が導入されています。

## ローカル開発

1. Unity プロジェクトを新たに作成します（テンプレートは問いません）
1. プロジェクトのルートディレクトリ直下にある `Packages` ディレクトリ以下にこの Git リポジトリをクローンします
1. `Analyzer~` ディレクトリを `Analyzer` にリネームします
1. 一度テキストエディタを閉じて Unity Editor を開きます
1. `Packages/Extreal.Core.Logging/Runtime/Extreal.Core.Logging.asmdef` を選択し、Inspector の中の `Assembly Definition References` に `Extreal.Core.Logging.Analyzer` を追加します
1. `Edit > Preferences...` を開きます
1. `External Tools` タブ内の `Generate .csproj files for:` のうち `Embedded packages` にチェックを付けます
1. `Regenerate project files` ボタンを押します

以上でセットアップは終了です。

## コントリビュータへ

コントリビュートするときは `develop` ブランチから新たなブランチを切ってください。

<ブランチ名の例>

- 機能を追加するとき
  - feature/<機能名>
- バグ修正をするとき
  - bugfix/<バグの概略>
