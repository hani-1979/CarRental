<script>
    $(document).ready(function() {
        // Initialize the date picker with date-only format
        $('#datepicker').datepicker({
            format: 'mm/dd/yyyy',  // Date format
            autoclose: true,        // Close the picker when a date is selected
            todayHighlight: true    // Highlight today's date
        });
    });
</script>