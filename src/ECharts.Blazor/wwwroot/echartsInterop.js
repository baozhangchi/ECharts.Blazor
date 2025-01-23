export function init(elementId, option) {
    let chartElement = document.getElementById(elementId);
    let chart = echarts.init(chartElement, 'light');
    if (chart) {
        initOption(elementId, option);
        console.log(option);
        chart.setOption(option);
    }
    const resizeObserver = new ResizeObserver(() => {
        chart.resize();
    });

    resizeObserver.observe(chartElement);
}

export function setOption(elementId, option, notMerge = false, lazyUpdate = false) {
    const chart = getChartByElementId(elementId);
    if (chart) {
        initOption(elementId, option);
        console.log(option);
        chart.setOption(option, notMerge, lazyUpdate);
    }
}

function initOption(elementId, option) {
    if (!option || !option.tooltip) {
        return;
    }

    if (option.tooltip.hasFormatter) {
        option.tooltip.formatter = (params, ticket, callback) => {
            DotNet.invokeMethodAsync('ECharts.Blazor', 'ValueFormatter', { id: option.tooltip.id, params: params, ticket: ticket }).then(res => {
                let element = document.getElementById(option.tooltip.id);
                let html = element.innerHTML;
                console.log(html);
                if (html) {
                    callback(ticket, html)
                }
                else {
                    callback(ticket, null)
                }
            });
            return 'Loading';
        }
    }
}

export function setTooltip(elementId, instance) {
    tooltip[elementId] = instance;
}

export function clearTooltip(elementId) {
    tooltip[elementId] = null;
}

export function dispose(elementId) {
    const chart = getChartByElementId(elementId);
    chart.dispose();
}

function getChartByElementId(elementId) {
    const chartElement = document.getElementById(elementId);
    if (!chartElement) {
        return undefined;
    }

    return echarts.getInstanceByDom(chartElement);
}