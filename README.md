
# CARO - TOP GAME KINH ĐIỂN NHẤT MỌI THỜI ĐẠI

```
* Mã lớp: IT008.J11
* Giảng viên phụ trách: Huỳnh Tuấn Anh
* Danh sách nhóm:
1. 15520756 - Lê Nguyễn Minh Tâm (nhóm trưởng)
2. 15520470 - Phạm Minh Mẫn
```

## **I. LỜI NÓI ĐẦU:**

### **1. Giới thiệu sơ lược cờ ca-rô:**

Cờ ca-rô (hay sọc ca-rô) là một trò chơi dân gian. Cờ ca-rô trong tiếng Triều Tiên là omok (오목), tiếng Trung là 五子棋 (bính âm: wǔzǐqí) và trong tiếng Nhật là 五目並べ (gomoku narabe); tiếng Anh, sử dụng lại tiếng Nhật, gọi là gomoku.

Ban đầu loại cờ này được chơi bằng các quân cờ vây (quân cờ màu trắng và đen) trên một bàn cờ vây (19x19). Quân đen đi trước và người chơi lần lượt đặt một quân cờ của họ trên giao điểm còn trống. Người thắng là người đầu tiên có được một chuỗi liên tục gồm 5 quân hàng ngang, hoặc dọc, hoặc chéo. Tuy nhiên, vì một khi đã đặt xuống, các quân cờ không thể di chuyển hoặc bỏ ra khỏi bàn, do đó loại cờ này có thể chơi bằng giấy bút. Ở Việt Nam, cờ này thường chơi trên giấy tập học sinh (đã có sẵn các ô ca-rô), dùng bút đánh dấu hình tròn (O) và chữ X để đại diện cho 2 quân cờ.

### **2. Luật chơi:**

Hai người chơi luân phiên đánh các nước cờ (x, o là hai ký tự thường được lựa chọn phổ biến nhất), người chơi nào đạt 5 quân cơ liên tiếp trên một hàng ngang, cột dọc hoặc đường chéo là người chiến thắng.

## **II. GIỚI THIỆU VỀ ỨNG DỤNG CỜ CARO DO NHÓM THỰC HIỆN:**

### **1. Giao diện chính:**

<p align="center">
    <img src="https://github.com/TamLNM/IT008.J11_Project/blob/master/CaroUI.PNG">
</p>

### **2. Giới thiệu tính năng:**
- Tính năng 1: Chơi với máy

Đây là tính năng giúp người chơi có thể trải nghiệm ván caro với máy tính. Liệu sự thông minh của bạn có chiến thắng AI player của chúng tôi ???

```
Để trải nghiệm tính năng này, người chơi thực hiện theo các bước sau đây:
* Bước 1: Khởi động ứng dụng Caro
* Bước 2: Click vào biểu tượng "Computer" ở thanh bên phải cửa sổ
```
<p align="center">
  <img src = "https://github.com/TamLNM/IT008.J11_Project/blob/master/Feature1.PNG">
</p>

- Tính năng 2: 2 người chơi (play-with-yourself)


- Tính năng 3: Kết nối giữa 2 người chơi trong cùng mạng LAN:

* Sơ đồ của 2 ứng dụng kết nối với nhau trong quá trình truyền tin:

<p align="center">
    <img src="https://github.com/TamLNM/IT008.J11_Project/blob/master/Connect_Desc.png">
</p>

Để 2 ứng dụng có thể giao tiếp với nhau, chúng phải có một không gian chung. Do đó, một trong 2 ứng dụng đang chạy phải có một anh đóng vai trò là server, anh còn lại sẽ có vai trò là client.
- Trong trường hợp đã có phòng (đã có server) anh còn lại chỉ việc vào phòng đó và thực hiện quá trình giao tiếp (khi này 2 ứng dụng đã thông nhau).
- Trong trường hợp chưa có phòng (chưa có server):  anh ứng dụng đã chạy sẽ đóng vai trò là người mở đầu - người tạo server cho anh còn lại vào.

 Quá trình kết nối được diễn ra như sau:
 - Nếu như đã có phòng, ứng dụng sẽ kết nói vào (đóng vai trò là client).
 - Nếu như chưa có, ứng dụng sẽ tạo server.
 
 Để 2 ứng dụng có thể kết nối với nhau thì cần có 2 điều kiện:
 - Chung IP. Có thể thiết lập bằng cách kết nối tới cùng một IP (IP này do người dùng đặt).
 - Chung Port.
 






