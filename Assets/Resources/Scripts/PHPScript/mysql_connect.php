//PDO MySQL�ڑ�
function connectDB(){

//���[�U����DB�A�h���X�̒�`
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