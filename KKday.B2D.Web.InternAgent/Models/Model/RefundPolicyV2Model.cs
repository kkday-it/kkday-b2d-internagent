namespace KKday.B2D.Web.InternAgent.Models.Model;

public class RefundPolicyV2Model
{ 
    public string display_type { get; set; }
    public string deadline_type { get; set; } // Deadline type, one of 'GO_DATE', 'CREATE_DATE', 'SPECIFIED_DATE'
    public string calculate_type { get; set; }
    public List<PatialRefundV2> partial_refund { get; set; }
    public string policy_type { get; set; } // 1: Free cancellation, 2: Non-cancellable, 3: Partial handling fee (conditional cancellation)
    public string refund_type { get; set; } //  'PERCENT', 'FIX'
}

public class PatialRefundV2
{
    public string fee_type { get; set; }
    public List<Fee> fee { get; set; }
    public DayTimeRule day_time_rule { get; set; }
    public PartialRefund display_rule { get; set; }
}

public class DayTimeRule
{
    public int? max { get; set; }
    public int? min { get; set; }
}

public class Fee
{
    public decimal? value { get; set; }
    public string calculate_type { get; set; }
}
 
public class BeforeDays
{
    public string unit { get; set; }
    public int? value { get; set; }
}

public class BeforeProcessTime
{
    public string end { get; set; }
    public string begin { get; set; }
}

public class LeadDay
{
    public string timezone { get; set; }
    public BeforeDays before_days { get; set; } //前置日時間
    public BeforeProcessTime before_process_time { get; set; } //可處理時間範圍
}