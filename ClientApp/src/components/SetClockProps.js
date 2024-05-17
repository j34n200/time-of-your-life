import { useState, useEffect } from 'react'
import ClockProps from './ClockProps'

function SetClockProps(props) {
    const clockProps = new ClockProps()
    const [titleText, setTitleText] = useState(clockProps.titleText)
    const [fontFamily, setFontFamily] = useState(clockProps.fontFamily)
    const [fontColor, setFontColor] = useState(clockProps.fontColor)
    const [clockFontColor, setClockFontColor] = useState(clockProps.clockFontColor)
    const [titleFontsize, setTitleFontSize] = useState(clockProps.titleFontSize)
    const [clockFontsize, setclockFontSize] = useState(clockProps.clockFontSize)
    const [blinkColons, setBlinkColons] = useState(clockProps.blinkColons)
    const [presets, setPresets] = useState([])
    const [loading, setLoading] = useState(true)
    const [isInputValid, setInputIsValid] = useState(true)
    const [open, setOpen] = useState(true)

    useEffect(() => {
    ;(async () => {
        const response = await fetch('clock/presets')
        const data = await response.json()
        setPresets(data)
        setLoading(false)
    })()
    }, [])

    const getProps = () => {
        const props = new ClockProps()
        props.titleText = document.getElementById('titleText').value
        props.fontFamily = document.getElementById('fontFamily').value
        props.titleFontSize = document.getElementById('titleFontSize').value
        props.clockFontSize = document.getElementById('clockFontSize').value
        props.fontColor = document.getElementById('fontColor').value
        props.clockFontColor = document.getElementById('clockFontColor').value
        props.blinkColons = document.getElementById('blinkColons').checked

        return props
    }

    const validateTextInputFields = (fieldValue) => {
        setInputIsValid(fieldValue.length > 0)
    }

    const handleOnKeyDown = (e) => {
        if (e.key === 'Enter') {
            setClockProps()
        }
    }

    const toogle = () => {
        setOpen(!open)
    }

    const setClockProps = () => {

        if (isInputValid) {
            const setProps = getProps()
            props.setClockProps(setProps)
        }
        else {
            alert('The inputs are not valid.')
            return
        }
    }

    const fontSizeOptions = (selctedSize) => {
    return clockProps.availableFontSizes.map((size) => {
        var option = <option>{size}</option>
        if (size === selctedSize) {
        option = <option selected>{size}</option>
        }
        return option
    })
    }

    const setTitleTextUI = () => {
        let titleVal = document.getElementById('titleText').value
        setTitleText(titleVal)
        clockProps.titleText = titleVal
        validateTextInputFields(titleVal);
    }

    const setFontFamilyUI = () => {
        setFontFamily(document.getElementById('fontFamily').value)
        clockProps.fontFamily = document.getElementById('fontFamily').value
    }

    const setFontColurUI = (e) => {
        setFontColor(document.getElementById('fontColor').value)
        clockProps.fontColor = document.getElementById('fontColor').value
    }

    const setClockFontColurUI = () => {
        let fontColorVal = document.getElementById('clockFontColor').value
        setClockFontColor(fontColorVal)
        clockProps.cloc = fontColorVal
        validateTextInputFields(fontColorVal);
    }

    const setBlinkColonsUI = () => {
        setBlinkColons(document.getElementById('blinkColons').checked)
        clockProps.blinkColons = document.getElementById('blinkColons').checked
        setClockProps()
    }

    const setCustomPreset = (p) => {
        let clockProps = new ClockProps()

        clockProps.id = p.id
        clockProps.titleText = p.title
        clockProps.fontFamily = p.fontFamily
        clockProps.fontColor = p.fontColor
        clockProps.clockFontColor = p.clockFontColor
        clockProps.titleFontSize = p.titleFontSize
        clockProps.clockFontSize = p.clockFontSize
        clockProps.blinkColons = p.blinkColons

        setTitleText(p.title)
        setFontFamily(p.fontFamily)
        setFontColor(p.fontColor)
        setTitleFontSize(p.titleFontSize)
        setclockFontSize(p.clockFontsize)
        setBlinkColons(p.blinkColons)
        setClockFontColor(p.clockFontColor)

        props.setClockProps(clockProps)
    }

    const presetsDisplay = (() => {
    console.log(presets)
    return loading ? (
        <div>
        This is a good place to display and use the presets stored on the sever.
        </div>
    ) : (
        <ul>
        {presets.map((p, i) => (
            <li>
            Preset {i + 1}:{' '}
                {`Title: ${p.title}, Font: ${p.fontFamily}, Title-Color: ${p.fontColor}, Clock-Color: ${p.clockFontColor}, Title Size: ${p.titleFontSize}, Clock Size: ${p.clockFontSize}, Clock Size: ${p.clockFontSize}, Blink Colons: ${p.blinkColons}`}
                <div></div>
                <button onClick={() => setCustomPreset(p)}>Set Preset</button>
            </li>
        ))}
        </ul>
    )
    })()

    return (
    <div id="ClockProps" style={{ overflow: 'auto' }}>
        <div
        style={{
            float: 'left',
            width: '40px',
            height: '100%',
            border: '1px solid white',
            fontSize: '20pt',
        }}
        >
        <a
            style={{ cursor: 'pointer' }}
            onClick={(e) => { toogle(e)} }
        >
            +/-
        </a>
        </div>
        <div>
        <div>
            <h1>Clock Properties</h1>
            <hr />
        </div>
                {open && (
                    <div >
                        <div>
                            <h2>Settings</h2>
                        </div>
                        <div>
                            <div>
                                <div>Title</div>
                                <div>
                                    <input
                                        id="titleText"
                                        value={titleText}
                                        onChange={setTitleTextUI}
                                        onKeyDown={(e) => handleOnKeyDown(e)}
                                    />
                                    <button onClick={setClockProps}>✓</button>
                                </div>
                            </div>

                            <div>Font Family</div>
                            <div>
                                <input
                                    id="fontFamily"
                                    value={fontFamily}
                                    onChange={setFontFamilyUI}
                                    onKeyDown={(e) => handleOnKeyDown(e)}
                                />
                                <button onClick={setClockProps}>✓</button>
                            </div>
                        </div>
                        <div>
                            <div>Title Font Size</div>
                            <div>
                                <input type="range" min="12" max="64" id="titleFontSize" list="titleFontSizes" defaultValue={titleFontsize} onChange={setClockProps}>

                                </input>
                                <datalist id="titleFontSizes">
                                    {fontSizeOptions(clockProps.titleFontSize)}
                                </datalist>
                            </div>
                        </div>
                        <div>
                            <div>Clock Font Size</div>
                            <div>
                                <input type="range" min="12" max="64" id="clockFontSize" list="clockFontSizes" defaultValue={clockFontsize} onChange={setClockProps}>
                                </input>
                                <datalist id="clockFontSizes">
                                    {fontSizeOptions(clockProps.clockFontSize)}
                                </datalist>
                            </div>
                        </div>
                        <div>
                            <div>Title Font Color</div>
                            <div>
                                <input
                                    id="fontColor"
                                    value={fontColor}
                                    onChange={(e) => setFontColurUI(e)}
                                    onKeyDown={(e) => handleOnKeyDown(e)}
                                />
                                <button onClick={setClockProps}>✓</button>
                            </div>
                        </div>
                        <div>
                            <div>Clock Font Color</div>
                            <div>
                                <input
                                    id="clockFontColor"
                                    value={clockFontColor}
                                    onChange={(e) => setClockFontColurUI(e)}
                                    onKeyDown={(e) => handleOnKeyDown(e)}
                                />
                                <button onClick={setClockProps}>✓</button>
                            </div>
                        </div>
                        <div>
                            <div>Blink Colons</div>
                            <div>
                                <input
                                    id="blinkColons"
                                    checked={blinkColons}
                                    type="checkbox"
                                    onChange={setBlinkColonsUI}
                                />
                            </div>
                        </div>
                        <div>
                            <div>
                                <button
                                    onClick={() =>
                                        alert('This should save the preset to the sever.')
                                    }
                                >
                                    Save Preset
                                </button>
                            </div>
                        </div>
                    </div>
        )}
        
        <hr />
        <div>
            <h2>Presets</h2>
            <div>{presetsDisplay}</div>
        </div>
        </div>
    </div>
    )
}

export default SetClockProps
