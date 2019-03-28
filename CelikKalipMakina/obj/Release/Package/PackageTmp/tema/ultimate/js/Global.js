
    $(document).on("click", "#btnMailGonder", function () {
        var Contact = new Object();
        Contact.AdiSoyadi = $("#AdiSoyadi").val();
        Contact.EMail = $("#EMail").val();
        Contact.Telefon = $("#Telefon").val();
        Contact.Mesaj = $("#Mesaj").val();
        Contact.Konu = $("#Konu").val();

        $.ajax({
            url: "/Home/MailIndex",
            data: Contact,
            type: "POST",
            dataType: 'json',
            success: function (response) {
                if (response.Success) {
                    swal("Tebrikler!", "Mail gönderimi Başarılı", "success");
                }
                else {
                    swal("Üzgünüm!", "Mail gönderimi Başarısız", "error");
                } 
                    
            }
        })
    })