-- ===================================================================
-- NothingTransparentSuite - Todo.lua
-- Task management script for Rainmeter Todo skin
-- ===================================================================

local MAX_TASKS = 6
local tasks = {}
local filePath = ''

function Initialize()
    filePath = SKIN:GetVariable('@') .. 'UserData\\tasks.txt'
    ReadTasks()
end

function PopulateDefaults()
    tasks = {
        {done = false, title = 'Завершить настройку Nothing Suite'},
        {done = false, title = 'Проверить шрифты NDot и Inter'},
        {done = true,  title = 'Активировать аппаратное ускорение Direct2D'},
        {done = false, title = 'Купить кофе'}
    }
    SaveTasks()
end

function ReadTasks()
    tasks = {}
    local file = io.open(filePath, 'r')
    if file then
        for line in file:lines() do
            line = line:gsub('\r', '')
            local status, text = line:match('^(%d)|(.*)$')
            if status and text and text ~= '' then
                table.insert(tasks, {done = (status == '1'), title = text})
            end
        end
        file:close()
    end

    if #tasks == 0 then
        PopulateDefaults()
    else
        UpdateMeters()
    end
end

function SaveTasks()
    local file = io.open(filePath, 'w')
    if file then
        for _, t in ipairs(tasks) do
            file:write((t.done and '1' or '0') .. '|' .. t.title .. '\n')
        end
        file:close()
    end
    UpdateMeters()
end

function AddTask(title)
    if not title then return end
    title = title:gsub('^%s+', ''):gsub('%s+$', '')
    if title == '' then return end

    table.insert(tasks, 1, {done = false, title = title})
    SaveTasks()
end

function ToggleTask(index)
    local idx = tonumber(index)
    if idx and tasks[idx] then
        tasks[idx].done = not tasks[idx].done
        SaveTasks()
    end
end

function DeleteTask(index)
    local idx = tonumber(index)
    if idx and tasks[idx] then
        table.remove(tasks, idx)
        SaveTasks()
    end
end

function ClearCompleted()
    local i = 1
    while i <= #tasks do
        if tasks[i].done then
            table.remove(tasks, i)
        else
            i = i + 1
        end
    end
    SaveTasks()
end

function UpdateMeters()
    local total = #tasks
    local completed = 0

    for i = 1, total do
        if tasks[i].done then
            completed = completed + 1
        end
    end

    local countStr = string.format('TASKS (%d/%d)', (total - completed), total)
    SKIN:Bang('!SetOption', 'MeterTodoHeader', 'Text', countStr)

    for i = 1, MAX_TASKS do
        local checkMeter = 'MeterTaskCheck' .. i
        local textMeter = 'MeterTaskText' .. i
        local delMeter = 'MeterTaskDel' .. i

        if tasks[i] then
            local checkSymbol = tasks[i].done and '[x]' or '[ ]'
            local textColor = tasks[i].done and '#ColorDone#' or '#ColorPrimary#'
            local checkColor = tasks[i].done and '#ColorAccent#' or '#ColorSecondary#'

            SKIN:Bang('!SetOption', checkMeter, 'Text', checkSymbol)
            SKIN:Bang('!SetOption', checkMeter, 'FontColor', checkColor)
            SKIN:Bang('!SetOption', checkMeter, 'Hidden', '0')

            SKIN:Bang('!SetOption', textMeter, 'Text', tasks[i].title)
            SKIN:Bang('!SetOption', textMeter, 'FontColor', textColor)
            SKIN:Bang('!SetOption', textMeter, 'Hidden', '0')

            SKIN:Bang('!SetOption', delMeter, 'Hidden', '0')
        else
            SKIN:Bang('!SetOption', checkMeter, 'Hidden', '1')
            SKIN:Bang('!SetOption', textMeter, 'Hidden', '1')
            SKIN:Bang('!SetOption', delMeter, 'Hidden', '1')
        end
    end

    SKIN:Bang('!UpdateMeterGroup', 'TodoGroup')
    SKIN:Bang('!Redraw')
end
