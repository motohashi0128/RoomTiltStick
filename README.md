
# RoomTiltStick
## 注意
学生時代にGithubの仕様を理解せずに巨大なファイルをアップロードしたため、通常の方法でのpullができません。
## 概要
自分で壁を押し、VR空間の部屋を回転させることで、VR空間の重力の方向と体重をかけている方向が一致し、VR空間の90度回転した重力が実際にあるように体験することができるVR体験装置です。

## 開発期間
2020年4月 - 2021年3月

## 使用技術
Unity 2021.3.6f1  
SteamVR  
HTC Vive  
Wii mote  
Unity OSC  
Processing  
└─ Wii moteを使用してPCにバランスWiiボードをBluetooth接続して値を取るが、PC一台につき一つのWiiボードしか接続できないため、二台目ののWiiボードを接続するために別のPCを用意し、Processingを使用して値を取得し、UnityにOSCで送信する。  
他、各種3Dアセットを使用

## 公開先
(映像) https://youtu.be/tw2tjo08T4w  
(展示) Siggraph Asia 2021 Tokyo

## ディレクトリ構成
```bash
.
├── .vscode
├── .gitignore
├── .gitattributes
├── Packages
├── Assets
│   ├── Scripts
│   │   └── Rolling.cs // メインのスクリプト
│   ├── Scenes 
│   │   └──New Scene 2.unity // 本番のシーン
.   .
.   .
.   .
```
