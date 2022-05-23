using System;
/// <summary>
///     会員情報を持つクラス
/// </summary>
class Member
{
    private int id;   //会員番号(連番)
    private string name;    //会員氏名
    private string insDt;   //登録日
    private int delFlg;     //削除フラグ
    public static int total = 0;

    /// <summary>
    ///     コンストラクタ(初期登録用)
    /// </summary>
    public Member(string name,String insDt){
        
        total += 1;        //オブジェクト作成時に加算

        setId(total);
        setName(name);
        setInsDt(insDt);
        setDelFlg(0);
    }

    /// <summary>
    ///     コンストラクタ(新規登録用)
    ///     　登録日付を今日の日付にする
    /// </summary>
    /// <param name="name">新規会員の氏名</param>
    public Member(string name){
        total += 1;

        //今日の日付(登録日時)を取得
        DateTime dt = DateTime.Now;
        String insDt = dt.ToString("yyyy/MM/dd");

        //setterに登録
        setId(total);
        setName(name);
        setInsDt(insDt);
        setDelFlg(0);
    }
    
    //getterおよびsetter
    public void setId(int id){
        this.id = id;
    }
    public int getId(){
        return id;
    }
    public void setName(string name){
        this.name = name;
    }
    public string getName(){
        return name;
    }
    public void setInsDt(string insDt){
        this.insDt = insDt;
    }
    public string getInsDt(){
        return insDt;
    }
    public void setDelFlg(int delFlg){
        this.delFlg = delFlg;
    }
    public int getDelFlg(){
        return delFlg;
    }

    /// <summary>
    ///     物理削除用のメソッド
    ///     連番用の数値をマイナスする
    /// </summary>
    public static void deleteMember(){
        total -= 1;
    }
}