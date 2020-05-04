//PDO MySQL接続
function connectDB(){

//ユーザ名やDBアドレスの定義
    $dsn = 'mysql:dbname=qiita;host=127.0.0.1;charset=utf8';
    $username = 'username';
    $password = 'passwd';

    try {
        $pdo = new PDO($dsn, $username, $password);
    } catch (PDOException $e) {
        exit('' . $e->getMessage());
    }

    return $pdo;
}