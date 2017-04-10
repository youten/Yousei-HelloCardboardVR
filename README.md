# Yousei-HelloCardboardVR

「VRエンジニア養成読本」の「特集1 Unityで作る 入門! VRアプリ開発」内、「第1章 Google CardboardとAndroidでスタート はじめてのVRアプリ」に記載した、UnityとGoogle VR SDKを用いたCardboard向けVRアプリサンプルのリポジトリです。

 * Google VR SDK（とPlugin）をgitignoreでリポジトリから外しています。Google VR SDK for Unityは別途importしてください。

書籍中では「Unity 5.5（の最新版）」となっていますが、本リポジトリはGoogle VR (CardboardとDaydream)のネイティブサポートの入ったUnity 5.6.0f3のプロジェクトとなっており、以下の2点対応済みのリポジトリとなっています。ややこしいのですがご了承ください。

 * Unity 5.6以降はVirtual Reality Supportedを有効にしてCardboardコンポーネントを追加する必要がある。
 * 一部APIがGoogle VRからUnity VRに変更となっているため、たとえば"GvrViewer.Instance.HeadPose.Orientation;"を"InputTracking.GetLocalRotation(VRNode.Head);"に変更するなどの対応を行う必要がある。
