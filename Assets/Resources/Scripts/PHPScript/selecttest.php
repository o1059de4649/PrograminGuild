require_once('mysql_connect.php');
$pdo = connectDB();

//POST�����Ƃ�
$id = $_POST["id"]; //�v������Ă���id

try {
    //���񂱂��ł�SELECT���𑗐M���Ă���BUPDATE�ADELETE�Ȃǂ́A�܂������L�@���قȂ�B
    $stmt = $pdo->query("SELECT * FROM `unity` WHERE `id` = '". $id. "'");
    foreach ($stmt as $row) {
		//����͂����J�������w�肵�A�o�͂��ꂽ��������������ďo��
        $res = $row['id'];
        $res = $res. $row['name'];
        $res = $res. $row['point'];
        $res = $res. $row['data'];
    }

} catch (PDOException $e) {
    var_dump($e->getMessage());
}
$pdo = null;    //DB�ؒf

echo $res;  //unity �Ɍ��ʂ�Ԃ�