export function initCalendar(calendarId, habits, redirectionDate) {
    return new FullCalendar.Calendar(document.getElementById(calendarId), {
        initialView: 'dayGridMonth',
        initialDate: redirectionDate,
        events: habits,
        dateClick: function (info) {
            window.location.href = `/HabitCompletions/Create?date=${info.dateStr}`;
        },
        editable: true,
        droppable: true,
        eventDrop: function (info) {
            let start = info.event.start;

            // Transformating Date to correct type
            let data = {
                Id: info.event.id,
                Date: start.getFullYear() + "-" +
                    String(start.getMonth() + 1).padStart(2, '0') + "-" +
                    String(start.getDate()).padStart(2, '0')
            };

            fetch('/Calendar/Save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
                .then(response => {
                    console.log("Odpowiedź z serwera:", response)
                    if (!response.ok) {
                        alert("Błąd podczas zapisu nowej daty.");
                        info.revert(); // cofa przesunięcie w kalendarzu
                    }
                });
        },
        customButtons: {
            habitButton: {
                text: 'Habits',
                click: function () {
                    window.location.href = `/Habits`;
                }
            },
            categoryButton: {
                text: '',
                click: function () {}
            },
        },
        headerToolbar: {
            left: 'title',
            center: '',
            right: 'categoryButton habitButton today prev,next'
        }
    });

}

//document.addEventListener('DOMContentLoaded', function () {
//    let calendarEl = document.getElementById('calendar');

//    let calendar = new FullCalendar.Calendar(calendarEl, {
//        initialView: 'dayGridMonth',
//        initialDate: "@ViewBag.RedirectionDate",
//        events: @Html.Raw(ViewData["Habits"]),
//        dateClick: function (info) {
//            window.location.href = `/HabitCompletions/Create?date=${info.dateStr}`;
//        },
//        editable: true,
//        droppable: true,
//        eventDrop: function (info) {
//            let start = info.event.start;

//            // Transformating Date to correct type
//            let data = {
//                Id: info.event.id,
//                Date: start.getFullYear() + "-" +
//                    String(start.getMonth() + 1).padStart(2, '0') + "-" +
//                    String(start.getDate()).padStart(2, '0')
//            };

//            fetch('/Calendar/Save', {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json'
//                },
//                body: JSON.stringify(data)
//            })
//                .then(response => {
//                    console.log("Odpowiedź z serwera:", response)
//                    if (!response.ok) {
//                        alert("Błąd podczas zapisu nowej daty.");
//                        info.revert(); // cofa przesunięcie w kalendarzu
//                    }
//                });
//        },
//        customButtons: {
//            habitButton: {
//                text: 'Habits',
//                click: function () {
//                    window.location.href = `/Habits`;
//                }
//            },
//            categoryButton: {
//                text: 'Category'
//            },
//        },
//        headerToolbar: {
//            left: 'title',
//            center: '',
//            right: 'habitButton today prev,next'
//        }
//    });

//    calendar.render();

//    // let draggableEl = document.getElementById('mydraggable');
//    // if (draggableEl) {
//    //   new FullCalendar.Draggable(draggableEl);
//    // }
//});