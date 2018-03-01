[](https://github.com/seiroise/SimpleInterp/blob/media/media/intrp.gif)

## 内容
- 簡単に補間を行える！
- 更新、終了のコールバック通知
- float, angle, Vector2, Vector3, Colorに対応
- 選べる四つの補間処理！
	- Liner, EaseIn, EaseOut, EaseInOut

## 使い方

自前でupdateする
```c#
// start関数とか

// float型で-5から5までを線形補間する。
// 更新時にOnUpdateにコールバックを受け、
// 終了時にOnFInishにコールバックを受ける。
var intrp = new IntrpFloat(-5f, 5f, IntrpType.Liner, OnUpdate, OnFinish);

// update関数とか
intrp.Update(Time.DeltaTime);
```

もっと便利にする。
managerにupdateしてもらう。
```c#
// 更新用のシングルトンを取得
// 自前で更新するなら必要ないです。
var manager = IntrpManager.instance;

// float型で135から-135までを角度依存でEaseIn補間する。
// 更新時にOnUpdateにコールバックを受け、
// 終了時にOnFInishにコールバックを受ける。
manager.Attach(new IntrpAngle(135f, -135f, IntrpType.EaseIn, OnUpdate, OnFinish));
```

