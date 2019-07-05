$(function () {
    
    //获取一级机构
    $.post("/api/GetConfigFileFirstKind", function (data) {
        console.log("加载一级分类")
        var firstSelect = $("#firstKindId");
        firstSelect.empty();
        firstSelect.append('<option value="">--请选择--</option>')
        for (i in data) {
            firstSelect.append('<option value="' + data[i].first_kind_id + '">' + data[i].first_kind_name + '</option>')
        }
    }, "json")
    //获取职位分类
    $.post("/api/GetAllMajorKindName", function (data) {
        console.log("加载职位分类")
        console.log(data)
        var majorSelect = $("#majorKindId");
        majorSelect.empty();
        majorSelect.append('<option value="">--请选择--</option>')
        for (i in data) {
            majorSelect.append('<option value="' + data[i].major_kind_id + '">' + data[i].major_kind_name + '</option>')
        }
    }, "json")


    //获取二级机构
    $("#firstKindId").change(function () {
        console.log("加载二级分类")
        $.post("/api/GetConfigFileSecondKindByFKID?fkid=" + $(this).val(), function (data) {
            var secondSelect = $("#secondKindId");
            secondSelect.empty();
            secondSelect.append('<option value="">--请选择--</option>')
            for (i in data) {
                secondSelect.append('<option value="' + data[i].second_kind_id + '">' + data[i].second_kind_name + '</option>')
            }
        }, "json")
    });
    //获取三级机构
    $("#secondKindId").change(function () {
        console.log("加载三级分类")
        $.post("/api/GetConfigFileThirdKindBySKID?skid=" + $(this).val(), function (data) {
            
            var thirdSelect = $("#thirdKindId");
            thirdSelect.empty();
            thirdSelect.append('<option value="">--请选择--</option>')
            for (i in data) {
                thirdSelect.append('<option value="' + data[i].third_kind_id + '">' + data[i].third_kind_name + '</option>')
            }
        }, "json")


    });

    $("#thirdKindId").change(function () {
        var thirdText = $("#thirdKindId").find("option:selected").text();

        $("#thirdKindName").val(thirdText);

    });
});

$(function () {
    $("#majorKindId").change(function () {
       
        $.post("/api/GetAllMajorName?mkid=" + $(this).val(), function (data) {
            console.log("加载职位名称")
            var majorSelect = $("#majorId");
            majorSelect.empty();
            majorSelect.append('<option value="">--请选择--</option>')
            for (i in data) {
                majorSelect.append('<option value="' + data[i].major_id + '">' + data[i].major_name + '</option>')
            }
        }, "json")

    });
    $("#majorId").change(function () {
        var majorIdText = $("#majorId").find("option:selected").text();
        $("#majorName").val(majorIdText);
    });

});