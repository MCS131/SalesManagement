#販売管理システム (Sales Management System)
Entity Framework Core を使用した Windows Forms ベースの販売管理システムです。
##概要
このシステムは、企業の販売業務全体を管理するための包括的なアプリケーションです。顧客管理から在庫管理、受注・発注処理まで、販売に関わる一連の業務をサポートします。
##主な機能
###マスタデータ管理

・顧客管理 - 顧客情報の登録・検索・更新
・商品管理 - 商品情報・価格・在庫設定の管理
・社員管理 - 社員情報・権限管理
・メーカー管理 - 取引先メーカー情報の管理

###取引管理

・受注管理 - 顧客からの注文受付と詳細登録
・注文管理 - 受注確定と注文処理
・発注管理 - メーカーへの発注処理
・売上管理 - 売上データの記録と管理

###在庫・物流管理

・在庫管理 - リアルタイム在庫数の管理
・入庫管理 - 発注品の入庫処理
・出庫管理 - 注文品の出庫処理
・入荷管理 - 入荷確認と記録
・出荷管理 - 出荷確認と記録

###セキュリティ機能

・ユーザーログイン認証
・役職別権限管理(管理者・営業・物流)
・データ非表示機能と理由記録

##技術スタック

・言語: C# (.NET Framework)
・UI: Windows Forms
・データベース: SQL Server (LocalDB)
・ORM: Entity Framework Core
・アーキテクチャ: Code First Approach

##プロジェクト構成
SalesManagement_SysDev/
├── Context/              # DbContext定義
├── Entity/              # エンティティモデル
├── Forms/               # UIフォーム
│   ├── DbAccess/       # データアクセス層
│   └── Common/         # 共通処理
└── README.md

##データベース構造
###マスタテーブル

・M_Client (顧客)
・M_Product (商品)
・M_Employee (社員)
・M_Maker (メーカー)
・M_Position (役職)
・M_SalesOffice (営業所)
・M_MajorClassification (大分類)
・M_SmallClassification (小分類)

###トランザクションテーブル

・T_Order (受注)
・T_Chumon (注文)
・T_Hattyu (発注)
・T_Sale (売上)
・T_Stock (在庫)
・T_Warehousing (入庫)
・T_Syukko (出庫)
・T_Arrival (入荷)
・T_Shipment (出荷)

各テーブルに対応する詳細テーブル(Detail)も実装されています。
##権限管理
役職アクセス可能機能管理者全機能アクセス可能営業顧客管理、受注・注文、入荷・出荷、売上管理物流商品管理、在庫管理、入庫・出庫、発注管理
##実装の工夫

###データ整合性の確保

Entity Framework の外部キー制約を活用
トランザクション処理による複数テーブルの同期更新


###ユーザビリティ

ページネーション機能による大量データの快適な閲覧
検索・フィルタリング機能の実装
ダブルクリックによるデータ選択


###入力検証

専用の検証クラス(DataInputFormCheck)による統一的な入力チェック
全角/半角、数値、文字数などの細かい検証


###業務フロー管理

状態フラグによる処理段階の管理
確定処理による後続処理の自動化



##セットアップ

###必要環境

Visual Studio 2019以降
.NET Framework 4.7.2以降
SQL Server LocalDB


###データベース接続

csharp   // SalesManagementContext.cs
   Data Source=(LocalDB)\\MSSQLLocalDB;
   Initial Catalog=SalesManagement;
   Integrated Security=True

###初回起動

Entity Framework の Migration を使用してデータベースを自動生成
データベース作成後、以下のSQLで初期アカウントを作成:



sql   -- 初期管理者アカウント
   INSERT INTO M_Position (PoID, PoName, PoFlag) VALUES (1, '管理者', 0);
   INSERT INTO M_SalesOffice (SoID, SoName, SoAddress, SoPhone, SoPostal, SoFAX, SoFlag) 
   VALUES (1, '本社', '東京都', '03-1234-5678', '1000001', '03-1234-5679', 0);
   INSERT INTO M_Employee (EmID, EmName, SoID, PoID, EmHiredate, EmPassword, EmPhone, EmFlag) 
   VALUES (1, 'admin', 1, 1, GETDATE(), 'admin123', '090-1234-5678', 0);

ログイン情報(テストアカウント)
社員IDパスワード権限用途12271227管理者全機能テスト3100310営業営業機能テスト1160116物流物流機能テスト
※ 初期データ投入後に使用可能

##今後の改善予定

 レポート機能の追加(売上分析、在庫レポート)
 Web APIの実装(モバイル対応)
 データエクスポート機能(Excel、CSV)
 監査ログ機能の強化

##作成者
チーム名: KY23
チームメンバー:
- リーダー: 柳川和博
- サブリーダー: マシュー クリスティ スサント
- 書記: 岩野和輝
- 小路瑛己
- 今村祐介
- 堤愛琉
