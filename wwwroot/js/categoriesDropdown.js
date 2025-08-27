import { initCalendar } from './calendar.js';

document.addEventListener('DOMContentLoaded', () => {
    // Calendar Init
    const calendar = initCalendar('calendar', habits, redirectionDate);
    calendar.render()

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