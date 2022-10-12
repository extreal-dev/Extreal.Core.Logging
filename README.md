# Extreal.Core

このライブラリは Unity 上での動作を想定しています。
また静的解析が導入されています。

## ローカル開発

1. Unity プロジェクトを新たに作成します（テンプレートは問いません）
1. プロジェクトのルートディレクトリ直下にある `Packages` ディレクトリ以下にこの Git リポジトリをクローンします

```bash
cd Packages
git clone https://github.com/extreal-dev/Extreal.Core.Logging.git
```

3. `develop` ブランチから任意のブランチを切ります

```bash
git checkout -b <branch>
```

4. `Analyzer~` ディレクトリを `Analyzer` にリネームします

```bash
mv Extreal.Core.Logging/Analyzer~ Extreal.Core.Logging/Analyzer
```

5. `Analyzer` ディレクトリ以下にある `.editorconfig` ファイルをプロジェクトのルートディレクトリ直下に移動します

```bash
mv Extreal.Core.Logging/Analyzer/.editorconfig ..
```

6. 一度テキストエディタを閉じます
1. Unity Editor の `Edit > Preferences...` を開きます
1. `External Tools` タブ内の `Generate .csproj files for:` のうち `Embedded packages` にチェックを付けます
1. `Regenerate project files` ボタンを押します

以上でセットアップは終了です。
