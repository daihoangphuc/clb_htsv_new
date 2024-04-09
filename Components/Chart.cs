using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using website_CLB_HTSV.Data;

namespace website_CLB_HTSV.Components
{
    public class Chart : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Chart(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Lấy danh sách hoạt động trong 12 tháng gần đây
            var activities = _context.HoatDong
                .Where(a => a.ThoiGian >= DateTime.Now.AddMonths(-11)) // Lấy hoạt động trong vòng 12 tháng
                .ToList();

            // Khởi tạo dictionary để lưu trữ số lượng tham gia theo tháng
            var participationData = new Dictionary<int, int>();

            // Tính toán dữ liệu tham gia theo tháng
            foreach (var activity in activities)
            {
                var month = activity.ThoiGian.Month;
                if (participationData.ContainsKey(month))
                {
                    participationData[month]++;
                }
                else
                {
                    participationData.Add(month, 1);
                }
            }

            // Tạo mảng chứa tên các tháng bằng tiếng Việt
            var vietnameseCulture = new CultureInfo("vi-VN");
            // Tạo mảng labels và data cho biểu đồ
            var labels = new string[12];
            var participatedCounts = new int[12];
            var currentMonth = DateTime.Now.Month;
            for (int i = 0; i < 12; i++)
            {
                var month = currentMonth - i;
                if (month <= 0)
                {
                    month += 12;
                }
                labels[i] = vietnameseCulture.DateTimeFormat.GetMonthName(month);
                if (participationData.ContainsKey(month))
                {
                    participatedCounts[i] = participationData[month];
                }
                else
                {
                    participatedCounts[i] = 0;
                }
            }

            ViewBag.MonthlyParticipationLabels = labels;
            ViewBag.MonthlyParticipationCounts = participatedCounts;

            return View("Index");
        }
    }
}
