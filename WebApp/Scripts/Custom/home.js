var home = {};

home = {
    
    createPossitionTable : function() {
        $.ajax({
            async: true,
            url: './api/Team',
            type: 'GET',
            data: {},
            cache: true,
            cacheLength: 60
        }).done(function (data) {
            
        }).fail(function (error) {
            alert(error.responseText);
        }).always(function () {
            
        });
    }
}