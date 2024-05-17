import { useState, useEffect } from 'react'

function Clock(props) {
    const [date, setDate] = useState(new Date())

    function refreshClock() {
        syncServerTime()
    }

    useEffect(() => {
        syncServerTime()
        const timerId = setInterval(refreshClock, 1000)
        return function cleanup() {
            clearInterval(timerId)
        }
    }, [])

    const syncServerTime = async() => {
        try {
            const response = await fetch('server/syncTime')
            const data = await response.json()
            setDate(new Date(data))
        } catch (e) {
            console.log(e)
        }
    }

    const numberToWords = (num) => {
        const ones = ['', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
        const tens = ['', '', 'twenty', 'thirty', 'forty', 'fifty'];

        if (num < 20) return ones[num];
        if (num < 60) return tens[Math.floor(num / 10)] + (num % 10 !== 0 ? ' ' + ones[num % 10] : '');

        // Case not handled
        return '';
    };

    const timeToWords = (time) => {
        const [hours, minutes] = time.split(':').map(Number);

        let hoursInWords = numberToWords(hours % 12 === 0 ? 12 : hours % 12);
        let minutesInWords = minutes === 0 ? '' : numberToWords(minutes);

        hoursInWords = hoursInWords.charAt(0).toUpperCase() + hoursInWords.slice(1);


        return `${hoursInWords}${minutesInWords ? ' ' + minutesInWords : ''}`;
    };

    const timeOptions = {
        timeZone: props.clockProps.timeZone
    };

    let displayText = date.toLocaleTimeString("en-US", timeOptions)
    if (props.clockProps.blinkColons & (date.getSeconds() % 2 === 0)) {
        displayText = displayText.replace(/:/g, ' ')
    }

    let displayWordsText = timeToWords(displayText)

    let displayStyle = {
        fontFamily: props.clockProps.fontFamily,
        color: props.clockProps.fontColor,
    }

    let titleStyle = {
        fontSize: `${props.clockProps.titleFontSize}pt`,
    }

    let clockStyle = {
        fontSize: `${props.clockProps.clockFontSize}pt`,
        color: props.clockProps.clockFontColor,
    }

  return (
    <div id="Clock">
      <div id="Digits" style={displayStyle}>
        <div id="title" style={titleStyle}>
            {props.clockProps.titleText}
        </div>
        <div id="time" style={clockStyle}>
          {displayText}
        </div>
        <div id="timeWords" style={clockStyle}>
            {displayWordsText}
        </div>
      </div>
    </div>
  );
}

export default Clock
