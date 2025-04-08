function initializeDynamicDataTable(tableColumns, tableId, headersRowId, baseUrl, fetchUrl, condColors) {
    const tableHeaders = $(headersRowId);
    let columns = [];

    // Clear previous headers
    tableHeaders.empty();

    console.log("condColors", condColors);
    const compiledConditions = [];
    // conditional formatting colors
    // Conditional formatting colors
    if (Array.isArray(condColors) && condColors.length > 0) {
        const currentYear = new Date().getFullYear();
        const mintNow = Date.now();
        const today = new Date().toISOString().split("T")[0];

        // Compile conditions dynamically
        for (const cond of condColors) {
            try {

                // Replace currentYear in the condition string with the actual currentYear value
                cond.Condition = cond.Condition.replace(/currentYear/g, currentYear);

                console.log("Evaluating condition:", cond.Condition);

                compiledConditions.push({
                    ...cond,
                    matcher: compileExpression(cond.Condition) 
                });
            } catch (e) {
                console.warn("Invalid condition:", cond.Condition, e);
            }
        }
    }       

    const formatDate = (dateStr) => {
        if (!dateStr) return '';
        const date = new Date(dateStr);
        const options = { day: '2-digit', month: 'short', year: 'numeric' };
        return date.toLocaleDateString(undefined, options);
    };

    const formatDecimal = (value) => {
        const num = parseFloat(value);
        return isNaN(num) ? '' : num.toFixed(2);
    };

    const EnumBasicDataTypes = {
        Boolean: 0,
        Byte: 1,
        Char: 2,
        DateTime: 3,
        Date: 4,
        DateTimeOffset: 5,
        Decimal: 6,
        Double: 7,
        Int16: 8,
        Int32: 9,
        Int64: 10,
        SByte: 11,
        Single: 12,
        String: 13,
        UInt16: 14,
        UInt32: 15,
        UInt64: 16
    };

    const getAlignClass = (dataType) => {
        const numericTypes = [
            EnumBasicDataTypes.Int16, EnumBasicDataTypes.Int32, EnumBasicDataTypes.Int64,
            EnumBasicDataTypes.UInt16, EnumBasicDataTypes.UInt32, EnumBasicDataTypes.UInt64,
            EnumBasicDataTypes.Decimal, EnumBasicDataTypes.Double, EnumBasicDataTypes.Single,
            EnumBasicDataTypes.Byte, EnumBasicDataTypes.SByte
        ];
        return numericTypes.includes(dataType) ? 'text-end' : 'text-start';
    };


    // Create headers and column definitions
    if (tableColumns?.Columns?.length > 0) {
        tableColumns.Columns.forEach(col => {
            const header = `<th style="width:${col.Width || 100}px" data-priority="${col.ResponsivePriority || 1}">${col.HeaderText || col.FieldName}</th>`;
            tableHeaders.append(header);

            let columnDef = {
                data: col.FieldName,
                visible: col.Visible,
                responsivePriority: col.ResponsivePriority || 1,
                className: getAlignClass(col.DataType)
            };

            // Apply formatting based on DataType (int enum values)
            switch (col.DataType) {
                case EnumBasicDataTypes.Date:
                case EnumBasicDataTypes.DateTime:
                case EnumBasicDataTypes.DateTimeOffset:
                    columnDef.render = function (data) {
                        return formatDate(data);
                    };
                    break;

                case EnumBasicDataTypes.Decimal:
                case EnumBasicDataTypes.Double:
                case EnumBasicDataTypes.Single:
                    columnDef.render = function (data) {
                        return formatDecimal(data);
                    };
                    break;
            }

            columns.push(columnDef);
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
            "orderable": false,
            className: 'text-start'
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
                autoWidth: false,
                buttons: ['copy', 'excel', 'pdf', 'colvis'],
                // this is the styling magic
                createdRow: function (row, rowData) {
                    for (const cond of compiledConditions) {
                        try {
                            const match = cond.matcher({ ...rowData });
                            if (match) {
                                $(row).css({
                                    "background-color": cond.BackColor,
                                    "color": cond.FontColor
                                });
                                break; // Only apply first matched condition
                            }
                        } catch (e) {
                            console.warn("Invalid condition:", cond.Condition, e);
                        }
                    }
                }
            }).buttons().container().appendTo(`${tableId}_wrapper .col-md-6:eq(0)`);
        })
        .catch(error => console.error("Error fetching data:", error));
}
