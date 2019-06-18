$(function () {
    //获取一级机构
    $.post("/api/GetConfigFileFirstKind", function (data) {
        var firstSelect = $("#firstKindId");
        firstSelect.empty();
        firstSelect.append('<option value="">--请选择--</option>')
        for (i in data) {
            firstSelect.append('<option value="' + data[i].first_kind_id + '">' + data[i].first_kind_name + '</option>')
        }
    }, "json")
    //选中一级机构时获取二级机构
    $("#firstKindId").change(function () {
        $.post("/api/GetConfigFileSecondKindByFKID?fkid=" + $(this).val(), function (data) {

            var secondSelect = $("#secondKindId");
            secondSelect.empty();
            secondSelect.append('<option value="">--请选择--</option>')
            for (i in data) {
                secondSelect.append('<option value="' + data[i].second_kind_id + '">' + data[i].second_kind_name + '</option>')
            }
        }, "json")
    });
    $("#secondKindId").change(function () {
        var secondText = $("#secondKindId").find("option:selected").text();
        $("#secondKindName").val(secondText);

        $.ajax({
            cache: false,
            url: "/HR_Fist/recruit/recruitAction!selectjilian3",
            data: "firstKind=" + $("#firstKindId").val() + "&secondId=" + $(this).val(),
            dataType: "xml",
            type: "POST",
            error: function () { alert("awewe"); },
            success: function (data) {
                var items = $(data).find("item");
                var thirdKind = $("#thirdKindId");
                thirdKind.html("<option value=''>--请选择--</option>");
                items.each(function (i) {
                    var option = $("<option></option>");
                    option.val($(items[i]).attr("id")).html($(items[i]).attr("value")).appendTo(thirdKind);

                });
            }
        });
    });

    $("#thirdKindId").change(function () {
        var thirdText = $("#thirdKindId").find("option:selected").text();

        $("#thirdKindName").val(thirdText);

    });
});

$(function () {
    $("#majorKindId").change(function () {
        var thirdText = $("#majorKindId").find("option:selected").text();
        $("#majorKindName").val(thirdText);

        $.ajax({
            cache: false,
            url: "/HR_Fist/recruit/recruitAction!findConfigMajorsByMajorKind",
            data: "majorKindId=" + $(this).val(),
            dataType: "xml",
            type: "POST",
            error: function (data) { alert("error"); },
            success: function (data) {
                var items = $(data).find("item");
                var majorId = $("#majorId");
                majorId.html("<option value=''>--请选择--</option>");
                items.each(function (i) {
                    var option = $("<option></option>");
                    option.val($(items[i]).attr("id")).html($(items[i]).attr("value")).appendTo(majorId);
                });
            }
        });
    });
    $("#majorId").change(function () {
        var majorIdText = $("#majorId").find("option:selected").text();
        $("#majorName").val(majorIdText);
    });

});