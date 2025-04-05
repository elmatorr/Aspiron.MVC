function initializeDynamicDataTable(tableColumns, tableId, headersRowId, baseUrl, fetchUrl) {
    const tableHeaders = $(headersRowId);
    let columns = [];

    // Clear previous headers
    tableHeaders.empty();

    // Create headers and column definitions
    if (tableColumns?.Columns?.length > 0) {
        tableColumns.Columns.forEach(col => {
            tableHeaders.append(`<th>${col.HeaderText || col.FieldName}</th>`);
            columns.push({ "data": col.FieldName, "visible": col.Visible });
        });
    }

    // Add Actions column if defined
    if (tableColumns?.Actions?.length > 0) {
        tableHeaders.append("<th>Actions</th>");
        columns.push({
            "data": null,
            "render": function (rowData, type, row) {
                return tableColumns.Actions.map(button => {
                    const idValue = row[button.IdField] || row.Id;
                    const url = `${baseUrl}${button.UrlTemplate.replace('__id__', idValue)}`;
                    return `<a href="${url}" class="btn btn-sm ${button.CssVisual} ${button.CssAction}">${button.DisplayText}</a>`;
                }).join(" ");
            },
            "orderable": false
        });
    }

    // Fetch and populate table
    fetch(fetchUrl)
        .then(res => res.json())
        .then(data => {
            $(tableId).DataTable({
                data: data,
                columns: columns,
                responsive: true,
                lengthChange: true,
                destroy: true,
                buttons: ['copy', 'excel', 'pdf', 'colvis']
            }).buttons().container().appendTo(`${tableId}_wrapper .col-md-6:eq(0)`);
        })
        .catch(error => console.error("Error fetching data:", error));
}
