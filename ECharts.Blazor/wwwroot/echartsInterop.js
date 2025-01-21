export function init(elementId, option) {
    let chartElement = document.getElementById(elementId);
    let chart = echarts.init(chartElement, 'light');

    if (chart) {
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
        chart.setOption(option, notMerge, lazyUpdate);
    }
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