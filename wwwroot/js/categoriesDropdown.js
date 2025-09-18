import { initCalendar } from './calendar.js';

document.addEventListener('DOMContentLoaded', () => {
    // Calendar Init
    const calendar = initCalendar('calendar', habits, redirectionDate);
    calendar.render()

    // CategoryColorsButton - changes colors of habits based on their colors attached to categories
    const categoryColorsBtn = document.querySelector('.fc-categoryColorsButton-button');
    if (!categoryColorsBtn || !categories) return;

    categoryColorsBtn.addEventListener('click', e => {
        var categoryColorsChecker = false;
        calendar.getEvents().forEach((event) => {
            if (event.extendedProps.CategoryId != null) {
                categories.forEach((category) => {
                    if (event.extendedProps.CategoryId == category.Id && !categoryColors) {
                        categoryColorsChecker = true;
                        event.setProp("color", category.BackgroundColor);
                        event.setProp("textColor", category.TextColor);
                    }
                    else if ((event.extendedProps.CategoryId == category.Id && categoryColors)) {
                        event.setProp("color", event.extendedProps.HabitColorShelf);
                        event.setProp("textColor", event.extendedProps.HabitTextColorShelf);
                    }
                });
            }
        });
        if (categoryColorsChecker) {
            categoryColors = true;
        } else {
            categoryColors = false;
        }
    })
    
    // CateoryButton - Replace button to dropdown with categories
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
            <li><a class="dropdown-item" href="#" data-cat-id="${cat.Id}" style="background-color: ${cat.BackgroundColor}; color: ${cat.TextColor}">
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