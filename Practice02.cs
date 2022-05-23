using System;
class Practice02
{
    /// <summary>
    ///  会員登録機能
    ///     以下の３つの機能を持つクラス
    ///     　表示機能：会員のリストを表示する。削除フラグの立っている会員は表示しない
    ///     　登録機能：会員を新規登録する
    ///     　削除機能：会員を論理削除する
    ///     　(終了機能)：プログラムを終了する
    /// </summary>
    static void Main()
    {
        //初期登録されているユーザを用意
        List<Member> memberList = new List<Member>();
        memberList.Add(new Member("鈴木一郎","2019/02/01"));
        memberList.Add(new Member("佐藤二郎","2019/02/04"));
        memberList.Add(new Member("加藤三郎","2019/02/10"));
        Console.WriteLine(memberList.Count);

        //変数の用意
        bool finFlg = false;    //trueの場合機能を終了する

        //会員登録機能開始
        while (finFlg != true){
            Console.WriteLine("機能を選択してください");
            Console.WriteLine("表示:1、登録:2、削除:3、終了:4");
            Console.Write(">");
            var option = Console.ReadLine();

            if (string.IsNullOrEmpty(option)) {
                //NULLの場合
                Console.WriteLine("1から4までの数字を入力してください。");

            }else if (option.Equals("1")){
                //表示機能
                Console.WriteLine("会員を表示します。：");
                //memberList内の会員のうち、削除フラグが立っていないものを表示。
                foreach(Member member in memberList){
                    Practice02.Select(member);
                }
            }else if (option.Equals("2")){
                //登録機能
                Console.WriteLine("登録する会員の氏名を入力してください。");
                
                var name ="";
                //空欄以外が入力されるまでループ
                while(true){
                    Console.Write(">");
                    name =Console.ReadLine();

                    if (string.IsNullOrEmpty(name)){
                        //空欄で入ってきた場合
                        Console.WriteLine("空欄は許容されません");
                        continue;
                    }
                    break;
                }

                Member newmember = new Member(name);
                Console.WriteLine("以下の内容で登録してよろしいでしょうか");
                Practice02.Select(newmember);

                Console.Write("登録を確定する：1、いいえ：2");
                //1か2が選択されるまで繰り返す
                option = Practice02.OneTwoCheck();

                if (option.Equals("1")){
                    //はいが選択された場合、会員をリストに登録し、機能選択画面へ戻る
                    memberList.Add(newmember);
                    continue;
                }else if (option.Equals("2")){
                    //いいえが選択された場合、登録した会員を物理削除する
                    Member.deleteMember();
                    continue;
                }

            }else if (option.Equals("3")){
                //削除機能
                
                //変数用意
                var memberIdStr ="";
                int memberId = 0;
                int i;
                
                Console.WriteLine("削除する会員の会員番号を入力してください");
                //会員番号の入力チェック
                while(true){
                    Console.Write(">");
                    memberIdStr = Console.ReadLine();
                    if(string.IsNullOrEmpty(memberIdStr)){
                        //入力値が空欄の場合
                        Console.WriteLine("削除する会員の会員番号を入力してください");
                        continue;
                    }else if (int.TryParse(memberIdStr, out i) == false){
                        //入力値がintに変換できない場合
                        Console.WriteLine("数値を入力してください。");
                        continue;
                    }else if (Int32.Parse(memberIdStr) <= 0 || memberList.Count < Int32.Parse(memberIdStr)){
                        //入力値が会員番号以外の数値の場合
                        Console.WriteLine("存在しない会員番号です。");
                        continue;
                    }
                    break;
                }

                memberId = Int32.Parse(memberIdStr);
                
                //削除する会員情報を表示　
                Console.WriteLine("以下の会員を削除してよろしいでしょうか");
                Member delMember = memberList[memberId-1];
                Practice02.Select(delMember);

                Console.Write("確定する：1、いいえ：2");
                //1か2が選択されるまで繰り返す
                option = Practice02.OneTwoCheck();

                if (option.Equals("1")){
                    //入力されたIDのMemberを、論理削除する。
                    delMember.setDelFlg(1);
                    
                }else if (option.Equals("2")){
                    //機能選択一覧に戻る
                    Console.WriteLine("いいえが選択されました。機能選択に戻ります。");
                    continue;
                }
                
            }else if (option.Equals("4")){
                //終了機能
                Console.WriteLine("終了しますか？  はい：1、いいえ：2");
                
                //1か2が選択されるまで繰り返す
                option = Practice02.OneTwoCheck();

                if (option.Equals("1")){
                    //はいが選択されたら、ループを抜ける
                    break;
                }else if (option.Equals("2")){
                    //いいえが選択されたら、機能選択へ戻る
                    continue;
                }
            }else{
                //1から4以外が入力されたら、機能選択画面へ戻る。
                Console.WriteLine("存在しない機能が選ばれました。1から4までの数字を入力してください。");
                continue;
            }

        }

        Console.WriteLine("終了します。");
    }

    /// <summary>
    ///     会員表示用メソッド
    /// </summary>
    /// <param name="member">Memberクラスのオブジェクト</param>
    public static void Select(Member member){
        if (member.getDelFlg() ==0) {
            //削除フラグが立っていない場合のみ、表示する
            int id = member.getId();
            string name = member.getName();
            string insDt = member.getInsDt();

            Console.WriteLine("ID：{0} 氏名：{1} 登録日：{2}",id,name,insDt);            
        }
    }

    /// <summary>
    ///     1か2が入力されるまで繰り返すメソッド
    /// </summary>
    /// <returns> string : 入力された数値(1か2)</returns>
    public static string OneTwoCheck(){
        var option = "";

        while(true){
            Console.Write(">");
            option = Console.ReadLine();

            if(string.IsNullOrEmpty(option)){
                //空欄で入力された場合
                Console.WriteLine("1か2を選択してください。");
                continue;
            }else if (!option.Equals("1") && !option.Equals("2")){
                //1,2以外の入力がされた場合
                Console.WriteLine("1か2を選択してください。");
                continue;
            }
            break;
        }
        
        return option;
    }

}
