function inicializarModal() {
    $('#Paciente_NumeroConvenio').parents('.form-group').hide();

    $('#Paciente_Telefone').mask('(00) 0 0000-0000');
    $('#Paciente_CPF').mask("999.999.999-99");
    $('#Paciente_NumeroConvenio').mask("0000000000");
}

var calendario = {
    /* initialize the calendar
-----------------------------------------------------------------*/
    objetoCalendario: null,
    inicializar: function () {

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        /*  className colors


        /* initialize the external events
        -----------------------------------------------------------------*/

        this.objetoCalendario = $('#calendar').fullCalendar({
            header: {
                left: 'title',
                center: 'agendaDay,agendaWeek,month',
                right: 'prev,next today'
            },
            editable: true,
            firstDay: 1, //  1(Monday) this can be changed to 0(Sunday) for the USA system
            selectable: true,
            defaultView: 'month',

            axisFormat: 'h:mm',
            columnFormat: {
                month: 'ddd',    // Mon
                week: 'ddd d', // Mon 7
                day: 'dddd M/d',  // Monday 9/7
                agendaDay: 'dddd d'
            },
            titleFormat: {
                month: 'MMMM yyyy', // September 2009
                week: "MMMM yyyy", // September 2009
                day: 'MMMM yyyy'                  // Tuesday, Sep 8, 2009
            },
            allDaySlot: false,
            selectHelper: true,
            select: function (start, end, allDay) {
                var title = prompt('Event Title:');
                if (title) {
                    calendar.fullCalendar('renderEvent',
                        {
                            title: title,
                            start: start,
                            end: end,
                            allDay: allDay
                        },
                        true // make the event "stick"
                    );
                }
                calendar.fullCalendar('unselect');
            },
            droppable: true, // this allows things to be dropped onto the calendar !!!
            drop: function (date, allDay) { // this function is called when something is dropped

                // retrieve the dropped element's stored Event Object
                var originalEventObject = $(this).data('eventObject');

                // we need to copy it, so that multiple events don't have a reference to the same object
                var copiedEventObject = $.extend({}, originalEventObject);

                // assign it the date that was reported
                copiedEventObject.start = date;
                copiedEventObject.allDay = allDay;

                // render the event on the calendar
                // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
                $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

                // is the "remove after drop" checkbox checked?
                if ($('#drop-remove').is(':checked')) {
                    // if so, remove the element from the "Draggable Events" list
                    $(this).remove();
                }

            },

            events: [
                {
                    title: 'All Day Event',
                    start: new Date(y, m, 1)
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: new Date(y, m, d - 3, 16, 0),
                    allDay: false,
                    className: 'info'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: new Date(y, m, d + 4, 16, 0),
                    allDay: false,
                    className: 'info'
                },
                {
                    title: 'Meeting',
                    start: new Date(y, m, d, 10, 30),
                    allDay: false,
                    className: 'important'
                },
                {
                    title: 'Lunch',
                    start: new Date(y, m, d, 12, 0),
                    end: new Date(y, m, d, 14, 0),
                    allDay: false,
                    className: 'important'
                },
                {
                    title: 'Birthday Party',
                    start: new Date(y, m, d + 1, 19, 0),
                    end: new Date(y, m, d + 1, 22, 30),
                    allDay: false,
                },
                {
                    title: 'Click for Google',
                    start: new Date(y, m, 28),
                    end: new Date(y, m, 29),
                    url: 'https://ccp.cloudaccess.net/aff.php?aff=5188',
                    className: 'success'
                }
            ],
        });

        $('#external-events div.external-event').each(function () {

            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
            // it doesn't need to have a start or end
            var eventObject = {
                title: $.trim($(this).text()) // use the element's text as the event title
            };

            // store the Event Object in the DOM element so we can get to it later
            $(this).data('eventObject', eventObject);

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true,      // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });

        });

    }
}

$(document).ready(function () {

    $('#expande-filtro').on('click', function () {
        let expandido = JSON.parse($(this).attr('aria-expanded'));
        let icone = $(this).find('i');
        if (expandido == true) {
            icone.removeClass('fa-minus');
            icone.addClass('fa-plus');
        }
        else {
            icone.removeClass('fa-plus');
            icone.addClass('fa-minus');
        }
    });

    $("tr.linha-conteudo").on('click', function () {
        $(this).addClass("table-dark").siblings().removeClass("table-dark");
        $(this).addClass("selected").siblings().removeClass("selected");
    })

    $('#agendar').click(function () {
        let id = $('.table-responsive').find('tr.selected').find('th').first().text();

        if (id.length == 0) {
            let mensagem = "Selecione uma clínica!";
            $('#modal-alerta').find('.modal-body').html('<p>' + mensagem + '</p>');
            $("#modal-alerta").modal('toggle');
        }
        else {
            inicializarModal();
            calendario.inicializar();
            $('#modal-agenda').modal('toggle');
        }
    })

    $('#Paciente_PossuiConvenio').click(function () {
        let marcado = $(this).is(':checked');
        if (marcado) {
            $('#Paciente_NumeroConvenio').parents('.form-group').show();
        }
        else {
            $('#Paciente_NumeroConvenio').parents('.form-group').hide();
            $('#Paciente_NumeroConvenio').val('');
        }
    });
})