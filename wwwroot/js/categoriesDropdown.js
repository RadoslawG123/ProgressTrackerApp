import { initCalendar } from './calendar.js';

document.addEventListener('DOMContentLoaded', () => {
    // Calendar Init
    const calendar = initCalendar('calendar', habits, redirectionDate);
    calendar.render()

    const categoryColorsBtn = document.querySelector('.fc-categoryColorsButton-button');
    if (!categoryColorsBtn || !categories) return;

    categoryColorsBtn.addEventListener('click', e => {
        calendar.getEvents().forEach((event) => {
            if (event.extendedProps.categoryId != null) {
                categories.forEach((category) => {
                    console.log("Category", category)
                    console.log("Category background color", category.BackgroundColor);
                    if (event.extendedProps.categoryId == category.Id) {
                        event.setProp("color", category.BackgroundColor);
                        event.setProp("textColor", category.TextColor);
                    }
                });
            }
        });
    })
    

    // Replace button to dropdown with categories
    const btn = document.querySelector('.fc-categoryButton-button');
    if (!btn || !categories) return;

    let html = `
        <div class="dropdown">
            <a class="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown">
                Categories
            </a>
            <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#" data-cat-id="">
                Ignore Categories
            </a></li>`;

    categories.forEach(cat => {
        html += `
            <li><a class="dropdown-item" href="#" data-cat-id="${cat.Id}">
                ${cat.Name}
            </a></li>`;
    });

    html += `</ul></div>`;
    btn.innerHTML = html;

    btn.querySelectorAll('.dropdown-item').forEach(item => {
        item.addEventListener('click', e => {
            e.preventDefault();
            const catId = e.currentTarget.getAttribute('data-cat-id');
            window.location.href = `/Calendar?redirectionDate=${redirectionDate}&catId=${catId}`;
        });
    });
})