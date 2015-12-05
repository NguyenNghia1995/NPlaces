Tên ứng dụng: NPlaces
Nền tảng: Windows Phone 8.1
Người phát triển: Nguyễn Văn Nghĩa
Email: nguyennghia1995@outlook.com


I. Tổng quan về ứng dụng NPlaces
- Ứng dụng NPlaces cho phép lấy về các địa điểm gần đây và các thông tin chi tiết về các địa điểm đó như: tên, địa chỉ, vị trí, hình ảnh, website, rating, số điện thoại và những review của người sử dụng đối với những địa điểm này.
- Ứng dụng cho phép tìm kiếm 11 các loại đia điểm bao gồm:
  + ATM
  + Cafe
  + Cinema
  + Food
  + Hospital
  + Police
  + University
  + Bar
  + Park
  + Post Office
 - Ứng dụng sử dụng Google Place API Web Service để lấy dữ liệu thô.


 II. Tổng quan về Google Place API

 - Google Place API do Google cung cấp cho phép cúng ta lấy về thông tin chi tiết của các địa điểm.
 - Các request thường dùng để lấy dữ liệu thô. Mỗi request phải bắt buộc có KeyAPI.
 	+ Tìm kiếm vị trí gần đây: https://maps.googleapis.com/maps/api/place/nearbysearch/json?
 	Mỗi lần request tối đa có 20 địa điểm kết quả được trả về. Các tham số bắt buộc là types, radius, location, key
 	+ Lấy thông tin chi tiết của một địa điểm: https://maps.googleapis.com/maps/api/place/details/json?
 	Tham số bắt buộc placeid (placeid của một địa điểm), key
 	+ Lấy tất cả các hình ảnh của một địa điểm: https://maps.googleapis.com/maps/api/place/photo?
 	Tham số bắt buộc photo_reference, key
 	+ Tìm kiếm địa điểm bằng text: https://maps.googleapis.com/maps/api/place/textsearch/json?


 III. Tối ưu ứng dụng, kiểm thử

 1, Tối ưu
 - Google Place API cho chúng ta lựa chọn hai kiểu lưu trữ kết quả trả về là json và xml. Không gian lưu trữ của json chiếm ít không gian hơn hơn xml rất nhiều (giảm thiểu việc chờ download kết quả trả về), cũng như các xử lý json nhanh hơn xml nên ứng dụng chọn json lưu kết quả trả về.

 - Hạn chế tối đa số request. Sử dụng hình ảnh local nếu có thể thay vì sử dụng hình ảnh từ internet. Vì để hiển thị 1 hình ảnh từ internet cũng cần 1 request.

 - Để hạn chế ứng dụng load chậm khi phải chờ đợi request, có thể dùng các animation. Ví dụ hình ảnh sẽ được hiển thị từ mờ (Opacity = 0) lên mức bình thường (Opacity = 1) trong vòng 1s. Như vậy sẽ có cảm giác ứng dụng sẽ có cảm giác mượt.

 2. Test
 - Sử dụng các khối try catch để bắt lỗi trong quá trình phát sinh, và Show log (Debug.Write) để hiện có thông tin về chi tiết lỗi, và fix lỗi.
 - Kiểm tra bộ nhớ mà ứng dụng đã sử dụng trong quá trình chạy bằng hàm CheckMemoryUse();
 - Video demo test app: https://www.youtube.com/watch?v=cdcy1DnT4ws





