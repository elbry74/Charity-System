var url = window.location;


$(".DateField").attr("readonly","true");
// for sidebar menu entirely but not cover treeview
$('ul.nav-stacked a').filter(function () {
    return this.href == url;
}).parent().addClass('active');

// for treeview
$('ul.nav-stacked a').filter(function () {
    return this.href == url;
}).parentsUntil(".sidebar-menu > .submenu").addClass('active');
$('ul.nav-stacked a').filter(function () {
    return this.href == url;
}).parentsUntil(".nav-stacked > .submenu").show();
 
//$('#sidebar-nav ul li ul  li ul li').click(function () {
//    $('#sidebar-nav').addClass('open')
//    $(this).parent().css("display", "block");
//    $(this).parent().parent().addClass('open');
//})

$(document).ready(function () {
    
            $(".DateField").attr("readonly","true");
            $('.selectpicker').selectpicker({
                style: 'btn-success',
                size: 8,
                liveSearch: true
            });
            $('.selectpickerdefault').selectpicker({
                style: 'bg-gray',
                size: 8,
                liveSearch: true
            });
            $('.selectpickerdefaultNoSearch').selectpicker({
                style: 'bg-gray',
                size: 8,
            });

            $(".DateField").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                yearRange: "-150:+50"
            });

            $(".DateFieldyearR").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                yearRange: "-150:+150"
            });
            $(".DateFieldyear").datepicker({
                changeMonth: false,
                changeYear: true,
                dateFormat: 'yy',
                yearRange: "-150:+150"
            });
            $(".DateFrom").datepicker({

                maxDate: "+0D",
                dateFormat: 'dd/mm/yy',
                onSelect: function (selected) {
                    $(".DateTo").datepicker("option", "minDate", selected)
                }
            });

            $(".DateTo").datepicker({
                minDate: 0,
                maxDate: "+0D",
                dateFormat: 'dd/mm/yy',
                onSelect: function (selected) {
                    $(".DateFrom").datepicker("option", "maxDate", selected)
                }
            });

            $('.DateFrom').change(function () {
                $('.DateTo').val('');
            });
            function comparedate() {
                var startDt = $('.DateFrom').val();
                var endDt = $('.DateTo').val();
                if (startDt != "") {

                    if ((new Date(startDt).getTime() < new Date(endDt).getTime())) {


                    }
                    else {
                        alert("تاريخ الى اكبر من تاريخ من");
                        $('.DateTo').val('');
                    }
                }
                else {
                    alert("ادخل تاريخ من الاول");
                    $('.DateTo').val('');
                }

            }
            function isNumber(evt) {
                evt = (evt) ? evt : window.event;
                if (charCode == 9) {
                    return true;
                }
                var charCode = (evt.which) ? evt.which : evt.keyCode;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
        });

Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
    $('.DateField').prop('readonly', true);
   
    $('.selectpicker').selectpicker({
        style: 'btn-success',
        size: 8,
        liveSearch: true
    });
    $('.selectpickerdefault').selectpicker({
        style: 'bg-gray',
        size: 8,
        liveSearch: true
    });
    $('.selectpickerdefaultNoSearch').selectpicker({
        style: 'btn-default',
        size: 8
      
    });
   
        $(".DateField").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',
            yearRange: "-150:+0"
    });

    $(".DateFieldyearR").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy',
        yearRange: "-150:+150"
    });
        $(".DateFieldyear").datepicker({
            changeMonth: false,
            changeYear: true,

            dateFormat: 'yy',
            yearRange: "-150:+150"
        });
        $(".DateFrom").datepicker({

            maxDate: "+0D",
            dateFormat: 'dd/mm/yy',
            onSelect: function (selected) {
                $(".DateTo").datepicker("option", "minDate", selected)
            }
        });

        $(".DateTo").datepicker({
            minDate: 0,
            maxDate: "+0D",
            dateFormat: 'dd/mm/yy',
            onSelect: function (selected) {
                $(".DateFrom").datepicker("option", "maxDate", selected)
            }
        });

        $('.DateFrom').change(function () {
            $('.DateTo').val('');
        });
        function comparedate() {
            var startDt = $('.DateFrom').val();
            var endDt = $('.DateTo').val();
            if (startDt != "") {

                if ((new Date(startDt).getTime() < new Date(endDt).getTime())) {


                }
                else {
                    alert("تاريخ الى اكبر من تاريخ من");
                    $('.DateTo').val('');
                }
            }
            else {
                alert("ادخل تاريخ من الاول");
                $('.DateTo').val('');
            }

        }
    })

// Date Compare
        $('.DateFrom').change(function() {
            $('.DateTo').val('');
        });
        function comparedate(){
        var startDt=$('.DateFrom').val();
        var endDt=$('.DateTo').val();
            if( startDt != "" ){

            if( (new Date(startDt).getTime() < new Date(endDt).getTime()))
                    {
           

                    }
                    else{
                           alert("تاريخ الى اكبر من تاريخ من");
                            $('.DateTo').val('');
                        }
            }
            else{
            alert("ادخل تاريخ من الاول");
                $('.DateTo').val('');
            }
        
        }

        $('.Bday').change(function () {
            var selectedDate = $('.Bday').datepicker('getDate');
            var now = new Date();
            now.setHours(0, 0, 0, 0);
            if (selectedDate > now) {
                alert("لا يمكن ان يكون تاريخ الميلاد فى المستقبل");
                $('.Bday').val('');
            }

        });

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            if (charCode == 9) {
                return true;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function isNumberwithdot(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            if (key.length == 0) return;
            var regex = /^[0-9.,\b]+$/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

// DateRangePicker
 
// Map [Enter] key to work like the [Tab] key
// Daniel P. Clark 2014

// Catch the keydown for the entire document
$(document).keydown(function(e) {

  // Set self as the current item in focus
  var self = $(':focus'),
      // Set the form by the current item in focus
      form = self.parents('form:eq(0)'),
      focusable;

  // Array of Indexable/Tab-able items
  focusable = form.find('input,a,select,button,textarea,div[contenteditable=true]').filter(':visible');

  function enterKey(){
    if (e.which === 13 && !self.is('textarea,div[contenteditable=true]')) { // [Enter] key

      // If not a regular hyperlink/button/textarea
      if ($.inArray(self, focusable) && (!self.is('a,button'))){
        // Then prevent the default [Enter] key behaviour from submitting the form
        e.preventDefault();
      } // Otherwise follow the link/button as by design, or put new line in textarea

      // Focus on the next item (either previous or next depending on shift)
      focusable.eq(focusable.index(self) + (e.shiftKey ? -1 : 1)).focus();

      return false;
    }
  }
  // We need to capture the [Shift] key and check the [Enter] key either way.
  if (e.shiftKey) { enterKey() } else { enterKey() }
});