import React, { useEffect, useState } from 'react';
import {
  BrowserRouter as Router,
  useParams
} from "react-router-dom";
import api from '../Helpers/Api';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import { Line } from 'react-chartjs-2';

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const viewsOptions = {
  responsive: true,
  interaction: {
    mode: 'index',
    intersect: false,
  },
  stacked: false,
  plugins: {
    title: {
      display: true,
      text: 'Views',
    },
  },
  scales: {
    y: {
      type: 'linear',
      display: true,
      position: 'left',
    },
    y1: {
      type: 'linear',
      display: false,
      position: 'right',
      grid: {
        drawOnChartArea: false,
      },
    },
  },
};
const subscribersOptions = {
  responsive: true,
  interaction: {
    mode: 'index',
    intersect: false,
  },
  stacked: false,
  plugins: {
    title: {
      display: true,
      text: 'Subscribers',
    },
  },
  scales: {
    y: {
      type: 'linear',
      display: true,
      position: 'left',
    },
    y1: {
      type: 'linear',
      display: false,
      position: 'right',
      grid: {
        drawOnChartArea: false,
      },
    },
  },
};

let viewsCountGraphData = {
  datasets: [],
};
let subscribersCountGraphData = {
  datasets: [],
};

function Statistics() {
  const [channels, setChannels] = useState();
  const [statistics, setStatistics] = useState([]);
  let { id } = useParams();

  const addToCompare = (id, name) => {
    api.get('/statistics/channel?channelId=' + id + "&recordsNumber=20").then((res) => {
      setStatistics([statistics[0], res.data]);
    });
  }

  useEffect(() => {
    api.get('/statistics/channel?channelId=' + id + "&recordsNumber=20").then((res) => {
      console.log(res.data);
      setStatistics([res.data]);
    });
    if (channels === undefined || channels === null) {
      api.get('/repository/allchannels').then(res => {
        setChannels(res.data);
      });
    }
  }, []);

  viewsCountGraphData = {
    labels: ["a", "b", "c"],
    datasets: [{
      label: "test",
      data: [12, 3, 1],
      borderColor: 'rgb(100, 99, 132)',
        backgroundColor: 'rgba(255, 99, 132, 0.5)',
        yAxisID: 'y',
    }]
  }
  subscribersCountGraphData = {
    labels: ["a", "b", "c"],
    datasets: [{
      label: "test",
      data: [12, 3, 1],
      borderColor: 'rgb(100, 99, 132)',
        backgroundColor: 'rgba(255, 99, 132, 0.5)',
        yAxisID: 'y',
    }]
  }

  if (statistics[0] !== undefined) {
    let channel = statistics[0];

    const labels = channel.data.map(data => data.date.slice(0, -11).replace("T", ", "));
    viewsCountGraphData.labels = labels;
    subscribersCountGraphData.labels = labels;

    viewsCountGraphData.datasets[0] = {
      label: channel.name,
      data: channel.data.map(st => st.viewsCount),
      borderColor: 'rgb(255, 99, 132)',
      backgroundColor: 'rgba(255, 99, 132, 0.5)',
      yAxisID: 'y',
    };
    subscribersCountGraphData.datasets[0] = {
      label: channel.name,
      data: channel.data.map(st => st.subscribersCount),
      borderColor: 'rgb(255, 99, 132)',
      backgroundColor: 'rgba(255, 99, 132, 0.5)',
      yAxisID: 'y',
    };
    if (statistics[1] !== undefined) {
      let compareChannel = statistics[1];

      viewsCountGraphData.datasets[1] = {
        label: compareChannel.name,
        data: compareChannel.data.map(st => st.viewsCount),
        borderColor: 'rgb(100, 99, 132)',
        backgroundColor: 'rgba(100, 99, 132, 0.5)',
        yAxisID: 'y',
      };
      subscribersCountGraphData.datasets[1] = {
        label: compareChannel.name,
        data: compareChannel.data.map(st => st.subscribersCount),
        borderColor: 'rgb(100, 99, 132)',
        backgroundColor: 'rgba(100, 99, 132, 0.5)',
        yAxisID: 'y',
      };
    }
  }
 //console.log(subscribersCountGraphData);


  return (<>{statistics && channels ? (
    <div className='d-flex'>
      <div style={{width: "700px", marginBottom: "50px"}}>
        <Line options={viewsOptions} data={viewsCountGraphData} />

        <Line options={subscribersOptions} data={subscribersCountGraphData} />
      </div>
      <div>
        Compare with:    
        {channels.map(ch => {
          const { id, name } = ch;
          return <div style={{marginLeft: "20px", marginBottom:"20px"}} key={id} className='btn btn-secondary' onClick={() => addToCompare(id, name)}>{name}</div>
        })}
      </div>
      {/* <div>
        {statistics.data.map(st => {
          const { date, viewsCount } = st;
          return <div>{date.slice(0, -11).replace("T",", ")} = {viewsCount}</div>
        })}
      </div> */}
    </div>
  ) : <div>loading...</div>}</>)
}
export default Statistics;