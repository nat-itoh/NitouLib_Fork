# Nitou Unity Lib

## 【概要】

自分用に Unity での開発で頻繁に使用するコードを試験的にパッケージとして切り出している．
パッケージ群は[Basic]と[Aditional]の２層に分類され，
全プロジェクトで共通して使用するモジュールは[Basic]，
オプションとして追加したいモジュールは[Aditional],
エディタ用のツール群は[Tools]として振り分ける．

![image](https://github.com/user-attachments/assets/4e5f3e04-d02f-4463-b678-91145a08c979)

※PackageManager で自作パッケージの依存関係を解決（自動インストール）する方法が分かっていないため，
できるだけパッケージ数は少なくしたい

## 【パッケージ】

本リポジトリは以下のパッケージを内包している．

- Nitou Lib [Basic]
- Nitou UI [Basic]
- Nitou Modules [Adittional]
- Nitou Tools [Tools]

導入するコードを選択可能にするため，複数パッケージに分割している．
（※あまりアセンブリファイルを増やしたくないので，分割方法は使いながら調整していく）

-***Nitou.Lib***
拡張メソッドやユーティリティ関数などの汎用的なライブラリ．
s
```
https://github.com/nitou-kanazawa/NitouUnityLib.git?path=Assets/com.nitou.nLib
```

- ***Nitou.UI***
```
https://github.com/nitou-kanazawa/NitouUnityLib.git?path=Assets/com.nitou.nUI
```

- ***Nitou.Modules***
```
https://github.com/nitou-kanazawa/NitouUnityLib.git?path=Assets/com.nitou.nModules
```

- ***Nitou.Tools***
```
https://github.com/nitou-kanazawa/NitouUnityLib.git?path=Assets/com.nitou.nTools
```

## 【構成】

導入するコードを選択可能にするため，以下のように複数パッケージに分ける．
（※あまりアセンブリファイルを増やしたくないので，分割方法は使いながら調整していく）

- Nitou Lib
- Nitou Tools

---

#### Nitou Lib

基本的な拡張メソッドや Math 関連の汎用クラス（構造体）を備えたライブラリ．

【依存パッケージ】

- UniTask :
- UniRx :

#### Main Modules

#### Tools

- Scene Switcher
- Todo List
- Material Watcher

#### Framwork
